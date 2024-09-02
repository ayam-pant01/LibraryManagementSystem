using LMS.WebAPI.Entities;
using LMS.WebAPI.Services;

namespace LMS.WebAPI.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category?> GetCategoryByIdAsync(int categoryId);
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<bool> CheckCategoryExistsAsync(int categoryId);
        Task AddCategoryAsync(Category category);
        Task<bool> SaveChangesAsync();
    }
}
