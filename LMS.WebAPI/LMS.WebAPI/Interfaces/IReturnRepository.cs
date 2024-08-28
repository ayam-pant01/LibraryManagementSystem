using LMS.WebAPI.Entities;
using LMS.WebAPI.Services;

namespace LMS.WebAPI.Interfaces
{
    public interface IReturnRepository
    {
        
        Task<(IEnumerable<Checkout>, PaginationMetaData)> GetUsersWithCheckedOutBooksAsync(string? name, int pageNumber, int pageSize);
        Task<IEnumerable<CheckoutDetail>> GetCheckoutDetailsByCheckoutIdAsync(int checkoutId);
        Task ReturnBookAsync(int checkoutDetailId);
        Task<bool> SaveChangesAsync();
    }
}
