using LMS.WebAPI.DBContexts;
using LMS.WebAPI.Entities;
using LMS.WebAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace LMS.WebAPI.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly LMSDBContext _lmsDbContext;

        public CategoryRepository(LMSDBContext lmsDbContext)
        {
            _lmsDbContext = lmsDbContext;
        }
        public async Task AddCategoryAsync(Category category)
        {
            await _lmsDbContext.Categories.AddAsync(category);
        }

        public async Task<bool> CheckCategoryExistsAsync(int categoryId)
        {
            return await _lmsDbContext.Categories.AnyAsync(c => c.CategoryId == categoryId);
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _lmsDbContext.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(int categoryId)
        {
            return await _lmsDbContext.Categories.FirstOrDefaultAsync(c => c.CategoryId == categoryId);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _lmsDbContext.SaveChangesAsync() >= 0);
        }
    }
}
