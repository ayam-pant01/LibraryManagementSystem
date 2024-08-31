using LMS.WebAPI.Entities;
using LMS.WebAPI.Services;

namespace LMS.WebAPI.Interfaces
{
    public interface ICheckoutRepository
    {
        Task<IEnumerable<Checkout>> GetUserCheckoutListAsync(string userId);
        Task<(IEnumerable<Checkout>, PaginationMetaData)> GetUsersWithCheckedOutBooksAsync(string? name, int pageNumber, int pageSize);
        Task<IEnumerable<CheckoutDetail>> GetCheckoutDetailsByCheckoutIdAsync(int checkoutId);
        Task CheckoutBooksAsync(string userId, List<int> bookIds);
        Task<bool> IsBookReturnedAsync(int bookId);
        Task<bool> SaveChangesAsync();
    }
}