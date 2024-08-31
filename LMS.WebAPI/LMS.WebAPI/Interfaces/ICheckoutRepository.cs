using LMS.WebAPI.Entities;

namespace LMS.WebAPI.Interfaces
{
    public interface ICheckoutRepository
    {
        Task<IEnumerable<Checkout>> GetUserCheckoutListAsync(string userId);
        Task CheckoutBooksAsync(string userId, List<int> bookIds);
        Task<bool> SaveChangesAsync();
    }
}