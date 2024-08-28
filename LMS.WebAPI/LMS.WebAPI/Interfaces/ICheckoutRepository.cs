using LMS.WebAPI.Entities;

namespace LMS.WebAPI.Interfaces
{
    public interface ICheckoutRepository
    {
        Task<Checkout?> GetCheckoutByIdAsync(int checkoutId);
        Task<IEnumerable<Checkout>> GetAllCheckoutsAsync();
        Task<IEnumerable<CheckoutDetail>> GetCheckoutDetailsByCheckoutIdAsync(int checkoutId);
        Task<IEnumerable<Checkout>> GetCheckoutsByUserIdAsync(string userId);
        Task CheckoutBooksAsync(string userId, List<int> bookIds);
        Task<bool> SaveChangesAsync();
    }
}