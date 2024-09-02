using LMS.WebAPI.Entities;

namespace LMS.WebAPI.Interfaces
{
    public interface IReviewRepository
    {
        Task AddReviewAsync(Review review);
        Task<Review?> GetReviewByBookAndUser(int bookId, string userId);
        Task<bool> CheckReviewExists(int bookId, string userId);
        void DeleteReview(Review book);
        Task<bool> SaveChangesAsync();
    }
}
