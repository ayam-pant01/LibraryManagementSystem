using LMS.WebAPI.DBContexts;
using LMS.WebAPI.Entities;
using LMS.WebAPI.Interfaces;
using LMS.WebAPI.Services;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace LMS.WebAPI.Repositories
{
    public class ReturnRepository : IReturnRepository
    {

        private readonly LMSDBContext _lmsDbContext;

        public ReturnRepository(LMSDBContext lmsDbContext)
        {
            _lmsDbContext = lmsDbContext;
        }

        public async Task ReturnBookAsync(int checkoutDetailId)
        {
            using var transaction = await _lmsDbContext.Database.BeginTransactionAsync();
            try
            {
                var checkoutDetails = await _lmsDbContext.CheckoutDetails
                    .Include(cd => cd.Book)
                    .Where(cd => cd.CheckoutDetailId == checkoutDetailId)
                    .FirstOrDefaultAsync();
                if(checkoutDetails!= null)
                {
                    checkoutDetails.ReturnedDate = DateTime.UtcNow;
                    checkoutDetails.Book.IsAvailable = true;
                }
                await _lmsDbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                await transaction.RollbackAsync();
                throw new Exception("An error occurred while returning book: The book must have been already returned to another user", ex);
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw new Exception("An error occurred while returning book");
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _lmsDbContext.SaveChangesAsync() >= 0);
        }
    }
}
