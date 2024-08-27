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
            return await _lmsDbContext.Books.Include(b => b.Category)
                                     .FirstOrDefaultAsync(b => b.BookId == id);
        }
        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _lmsDbContext.Books.Include(b => b.Category).ToListAsync();
        }

        public async Task<(IEnumerable<Book>, PaginationMetaData)> GetAllBooksAsync(string? title, string? searchQuery, int pageNumber, int pageSize)
        {
            var bookCollection = _lmsDbContext.Books.Include(b=>b.Category) as IQueryable<Book>;
            if (!string.IsNullOrWhiteSpace(title))
            {
                title = title.Trim();
                bookCollection = bookCollection.Where(c => c.Title == title);

            }

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim();
                bookCollection = bookCollection.Where(c => c.Title.Contains(searchQuery)
                    || (c.Description != null && c.Description.Contains(searchQuery))
                    || (c.Publisher != null && c.Publisher.Contains(searchQuery))
                    || (c.Author != null && c.Author.Contains(searchQuery)));

            }

            var totalItemCount = await bookCollection.CountAsync();
            var paginationMetaData = new PaginationMetaData(totalItemCount, pageSize, pageNumber);

            var collectionToReturn = await bookCollection.OrderBy(c => c.Title)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();
            return (collectionToReturn, paginationMetaData);
        }

        public async Task<bool> CheckBookExistsAsync(int bookId)
        {
            return await _lmsDbContext.Books.AnyAsync(c => c.BookId == bookId);
        }
        public async Task<bool> CheckBookExistsAsync(string isbn)
        {
            return await _lmsDbContext.Books.AnyAsync(c => c.ISBN == isbn);
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
