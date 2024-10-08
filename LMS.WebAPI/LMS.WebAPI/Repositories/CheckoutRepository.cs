﻿using LMS.WebAPI.DBContexts;
using LMS.WebAPI.Entities;
using LMS.WebAPI.Interfaces;
using LMS.WebAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace LMS.WebAPI.Repositories
{
    public class CheckoutRepository : ICheckoutRepository
    {
        private readonly LMSDBContext _lmsDbContext;
        private readonly IBookRepository _bookRepository;
        public CheckoutRepository(LMSDBContext lmsDbContext, IBookRepository bookRepository)
        {
            _lmsDbContext = lmsDbContext;
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Checkout>> GetUserCheckoutListAsync(string userId)
        {
            var checkoutCollection = _lmsDbContext.Checkouts
                .Include(c => c.CheckoutDetails)
                .ThenInclude(c=>c.Book)
                .Include(x => x.User) as IQueryable<Checkout>;
            var collectionToReturn = await checkoutCollection.Where(c=>c.UserId == userId).OrderBy(b => b.CheckoutDate).ToListAsync();
            return collectionToReturn;
        }

        public async Task<(IEnumerable<Checkout>, PaginationMetaData)> GetUsersWithCheckedOutBooksAsync(string? name, int pageNumber, int pageSize)
        {
            var checkoutCollection = _lmsDbContext.Checkouts
                .Include(c => c.CheckoutDetails) //maybe has performance issues as this will get all the detail data too, just need a count
                .Include(x => x.User) as IQueryable<Checkout>;

            if (!string.IsNullOrWhiteSpace(name))
            {
                var lowerName = name.ToLower(); // Perform case-insensitive search
                checkoutCollection = checkoutCollection.Where(c =>
                    c.User.FirstName.ToLower().Contains(lowerName) ||
                    (c.User.MiddleName != null && c.User.MiddleName.ToLower().Contains(lowerName)) ||
                    c.User.LastName.ToLower().Contains(lowerName));
            }

            var totalItemCount = await checkoutCollection.CountAsync();
            var paginationMetaData = new PaginationMetaData(totalItemCount, pageSize, pageNumber);

            var collectionToReturn = await checkoutCollection.OrderBy(b => b.CheckoutDate)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (collectionToReturn, paginationMetaData);
        }

        public async Task<IEnumerable<CheckoutDetail>> GetCheckoutDetailsByCheckoutIdAsync(int checkoutId)
        {
            return await _lmsDbContext.CheckoutDetails
                .Where(cd => cd.CheckoutId == checkoutId)
                .Include(cd => cd.Book)
                .ToListAsync();
        }

        public async Task CheckoutBooksAsync(string userId, List<int> bookIds)
        {
            using var transaction = await _lmsDbContext.Database.BeginTransactionAsync();
            try
            {
                var books = await _lmsDbContext.Books
                    .Where(b => bookIds.Contains(b.BookId))
                    .ToListAsync();

                var checkedOutBooks = books
                    .Where(book => !book.IsAvailable ||
                        _lmsDbContext.CheckoutDetails.Any(cd => cd.BookId == book.BookId && cd.ReturnedDate == null))
                    .ToList();

                if (checkedOutBooks.Any())
                {
                    var bookNames = string.Join(", ", checkedOutBooks.Select(b => b.Title));
                    throw new Exception($"The following books are already checked out: {bookNames}");
                }

                var checkout = new Checkout
                {
                    UserId = userId,
                    CheckoutDate = DateTime.UtcNow
                };

                var checkoutDetails = bookIds.Select(bookId => new CheckoutDetail
                {
                    BookId = bookId
                }).ToList();

                await _lmsDbContext.Checkouts.AddAsync(checkout);
                await SaveChangesAsync(); // saved to get new checkout  id

                foreach (var detail in checkoutDetails)
                {
                    detail.CheckoutId = checkout.CheckoutId;
                    detail.Checkout = checkout;
                }
                await _lmsDbContext.CheckoutDetails.AddRangeAsync(checkoutDetails);

                // Update books to be unavailable
                foreach (var book in books)
                {
                    book.IsAvailable = false;
                }

                await SaveChangesAsync();
                await transaction.CommitAsync();

            }
            catch(DbUpdateConcurrencyException ex)
            {
                await transaction.RollbackAsync();
                throw new Exception($"An error occurred while checking out books: One of the books must have been already checkedout by another user", ex);

            }
            catch (Exception ex)
            {

                await transaction.RollbackAsync();
                throw new Exception($"An error occurred while checking out books: {ex.Message}", ex);
            }
        }

        public async Task<bool> IsBookReturnedAsync(int bookId)
        {
            // decided to add index to checkout details table on bookid and returned date.
            return await _lmsDbContext.CheckoutDetails
                .AnyAsync(x => x.BookId == bookId && x.ReturnedDate != null);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _lmsDbContext.SaveChangesAsync() >= 0);
        }
    }
}
