using LMS.WebAPI.Entities;

namespace LMS.WebAPI.Interfaces
{
    public interface ICheckoutRepository
    {
        Task CheckoutBooksAsync(string userId, List<int> bookIds);
        Task<bool> SaveChangesAsync();
    }
}