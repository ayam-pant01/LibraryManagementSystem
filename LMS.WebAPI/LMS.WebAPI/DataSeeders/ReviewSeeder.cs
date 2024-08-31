using Bogus;
using LMS.WebAPI.Entities;
using System.Collections.Generic;

namespace LMS.WebAPI.DataSeeders
{
    public class ReviewSeeder
    {
        public static IEnumerable<Review> GenerateReviews(IEnumerable<int> bookIds, string userId)
        {
            var faker = new Faker<Review>()
                .RuleFor(r => r.UserId, f => userId) 
                .RuleFor(r => r.BookId, f => f.PickRandom(bookIds)) 
                .RuleFor(r => r.Rating, f => f.Random.Int(1, 5)) 
                .RuleFor(r => r.Comment, f => f.Lorem.Sentence(10)) 
                .RuleFor(r => r.ReviewDate, f => f.Date.Recent(365)); 
            var reviews = bookIds.Select(bookId => faker.Generate()).ToList();

            return reviews;
        }
    }
}
