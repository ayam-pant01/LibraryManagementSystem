using Bogus.DataSets;
using LMS.WebAPI.DBContexts;
using LMS.WebAPI.Entities;
using LMS.WebAPI.Interfaces;
using LMS.WebAPI.Services;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace LMS.WebAPI.Repositories
{
    public class BookRepository : IBookRepository
    {

        private readonly LMSDBContext _lmsDbContext;

        public BookRepository(LMSDBContext lmsDbContext)
        {
            _lmsDbContext = lmsDbContext;
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await _lmsDbContext.Books
                .Include(b => b.Category)
                .Include(b => b.Reviews)
                    .ThenInclude(r => r.User)
                    .FirstOrDefaultAsync(b => b.BookId == id);
        }
        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _lmsDbContext.Books
                .Include(b => b.Category)
                .Include(b => b.Reviews)
                    .ThenInclude(r => r.User)
                    .ToListAsync();
        }

        public async Task<(IEnumerable<Book>, PaginationMetaData)> GetAllBooksAsync(string? searchQuery, bool? isAvailable, string sortBy = "Title", bool isDecending = false, int pageNumber = 1, int pageSize = 10)
        {
            var bookCollection = _lmsDbContext.Books
                .Include(b => b.Category)
                .Include(b => b.Reviews)
                    .ThenInclude(r => r.User) as IQueryable<Book>;

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim();
                bookCollection = bookCollection.Where(b => b.Title.Contains(searchQuery)
                    || (b.Description != null && b.Description.Contains(searchQuery))
                    || (b.Publisher != null && b.Publisher.Contains(searchQuery))
                    || (b.Author != null && b.Author.Contains(searchQuery)));

            }
            if (isAvailable.HasValue)
            {
                bookCollection = bookCollection.Where(b => b.IsAvailable == isAvailable.Value);
            }

            bookCollection = sortBy.ToLower() switch
            {
                "author" => isDecending ? bookCollection.OrderByDescending(b => b.Author) : bookCollection.OrderBy(b => b.Author),
                "isAvailable" => isDecending ? bookCollection.OrderByDescending(b => b.IsAvailable) : bookCollection.OrderBy(b => b.IsAvailable),
                "categoryName" => isDecending ? bookCollection.OrderByDescending(b => b.Category.Name) : bookCollection.OrderBy(b => b.Category.Name),
                _ => isDecending ? bookCollection.OrderByDescending(b => b.Category.Name) : bookCollection.OrderBy(b => b.Category.Name),

            };

            var totalItemCount = await bookCollection.CountAsync();
            var paginationMetaData = new PaginationMetaData(totalItemCount, pageSize, pageNumber);

            var collectionToReturn = await bookCollection.OrderBy(b => b.Title)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();
            return (collectionToReturn, paginationMetaData);
        }

        public async Task<IEnumerable<Book>> GetFeaturedBooks()
        {
            return await _lmsDbContext.Books.OrderBy(b => Guid.NewGuid()).Take(6).ToListAsync();
        }

        public async Task<bool> CheckBookExistsAsync(int bookId)
        {
            return await _lmsDbContext.Books.AnyAsync(b => b.BookId == bookId);
        }
        public async Task<bool> CheckBookExistsAsync(string isbn)
        {
            return await _lmsDbContext.Books.AnyAsync(b => b.ISBN == isbn);
        }
        public async Task AddBookAsync(Book book)
        {
            await _lmsDbContext.Books.AddAsync(book);
        }

        public void DeleteBook(Book book)
        {
            _lmsDbContext.Books.Remove(book);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _lmsDbContext.SaveChangesAsync() >= 0);
        }
    }
}
