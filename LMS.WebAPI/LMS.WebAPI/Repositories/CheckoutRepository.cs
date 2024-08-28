using LMS.WebAPI.DBContexts;
using LMS.WebAPI.Entities;
using LMS.WebAPI.Interfaces;
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

        public async Task<IEnumerable<Checkout>> GetAllCheckoutsAsync()
        {
            return await _lmsDbContext.Checkouts
                 .Include(c => c.CheckoutDetails)
                 .ThenInclude(cd => cd.Book)
                 .ToListAsync();
        }

        public async Task<Checkout?> GetCheckoutByIdAsync(int checkoutId)
        {
            return await _lmsDbContext.Checkouts
                .Include(c => c.CheckoutDetails)
                .ThenInclude(cd => cd.Book)
                .FirstOrDefaultAsync(c => c.CheckoutId == checkoutId);
        }

        public async Task<IEnumerable<CheckoutDetail>> GetCheckoutDetailsByCheckoutIdAsync(int checkoutId)
        {
            return await _lmsDbContext.CheckoutDetails
                .Where(cd => cd.CheckoutId == checkoutId)
                .Include(cd => cd.Book)
                .ToListAsync();
        }

        public async Task<IEnumerable<Checkout>> GetCheckoutsByUserIdAsync(string userId)
        {
            return await _lmsDbContext.Checkouts
                .Where(c => c.UserId == userId)
                .Include(c => c.CheckoutDetails)
                    .ThenInclude(cd => cd.Book)
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
                await SaveChangesAsync();

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
            catch (Exception ex)
            {

                await transaction.RollbackAsync();
                throw new Exception($"An error occurred while checking out books: {ex.Message}", ex);
            }
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _lmsDbContext.SaveChangesAsync() >= 0);
        }
    }
}
