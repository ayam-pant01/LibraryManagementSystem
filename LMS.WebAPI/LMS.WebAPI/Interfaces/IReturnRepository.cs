using LMS.WebAPI.Entities;
using LMS.WebAPI.Services;

namespace LMS.WebAPI.Interfaces
{
    public interface IReturnRepository
    {
        
        Task ReturnBookAsync(int checkoutDetailId);
        Task<bool> SaveChangesAsync();
    }
}
