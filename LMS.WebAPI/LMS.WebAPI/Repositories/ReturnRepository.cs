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

        public async Task<IEnumerable<CheckoutDetail>> GetCheckoutDetailsByCheckoutIdAsync(int checkoutId)
        {
            return await _lmsDbContext.CheckoutDetails
                .Where(cd => cd.CheckoutId == checkoutId)
                .Include(cd => cd.Book)
                .ToListAsync();
        }

        public async Task<(IEnumerable<Checkout>, PaginationMetaData)> GetUsersWithCheckedOutBooksAsync(string? name, int pageNumber, int pageSize)
        {
            var checkoutCollection = _lmsDbContext.Checkouts
                .Include(c=>c.CheckoutDetails) //maybe has performance issues as this will get all the detail data too, just need a count
                .Include(x => x.User) as IQueryable<Checkout>;

            if (!string.IsNullOrWhiteSpace(name))
            {
                var lowerName = name.ToLower(); // Perform case-insensitive search
                checkoutCollection = checkoutCollection.Where(c =>
                    c.User.FirstName.ToLower().Contains(lowerName) ||
                    (c.User.MiddleName != null && c.User.MiddleName.ToLower().Contains(lowerName)) ||
                    c.User.LastName.ToLower().Contains(lowerName));
            }

            var totalItemCount = await checkoutCollection.CountAsync();
            var paginationMetaData = new PaginationMetaData(totalItemCount, pageSize, pageNumber);

            var collectionToReturn = await checkoutCollection.OrderBy(b => b.CheckoutDate)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (collectionToReturn, paginationMetaData);
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
