using LMS.WebAPI.Entities;
using LMS.WebAPI.Services;

namespace LMS.WebAPI.Interfaces
{
    public interface IBookRepository
    {
        Task<Book?> GetBookByIdAsync(int id);
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<(IEnumerable<Book>, PaginationMetaData)> GetAllBooksAsync(string? title, string? searchQuery, int pageNumber, int pageSize);
      
        Task<bool> CheckBookExistsAsync(int bookId);
        Task<bool> CheckBookExistsAsync(string isbn);
        Task AddBookAsync(Book book);
        //Task UpdateBookAsync(Book book);
        void DeleteBook(Book book);
        Task<bool> SaveChangesAsync();
    }
}
