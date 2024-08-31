using LMS.WebAPI.DBContexts;
using LMS.WebAPI.Entities;
using LMS.WebAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LMS.WebAPI.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly LMSDBContext _lmsDbContect;
        public ReviewRepository(LMSDBContext lmsDbContect)
        {
            _lmsDbContect = lmsDbContect;
        }
        public async Task AddReviewAsync(Review review)
        {
            await _lmsDbContect.Reviews.AddAsync(review);
        }

        public void DeleteReview(Review review)
        {
            _lmsDbContect.Reviews.Remove(review);
        }

        public async Task<Review?> GetReviewByBookAndUser(int bookId, string userId)
        {
           return await _lmsDbContect.Reviews.FirstOrDefaultAsync(r=>r.BookId == bookId && r.UserId == userId);
        }

        public async Task<bool> CheckReviewExists(int bookId, string userId)
        {
            return await _lmsDbContect.Reviews.AnyAsync(r => r.BookId == bookId && r.UserId == userId);
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
