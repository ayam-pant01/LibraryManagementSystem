using Bogus;
using LMS.WebAPI.Entities;

namespace LMS.WebAPI.DataSeeders
{
    public class BookSeeder
    {
        public static IEnumerable<Book> GenerateBooks(List<int> categoryIds)
        {
            var faker = new Faker<Book>()
                .RuleFor(b => b.Title, f => f.Commerce.ProductName())
                .RuleFor(b => b.Author, f => f.Name.FullName())
                .RuleFor(b => b.Description, f => f.Lorem.Paragraph())
                .RuleFor(b => b.CoverImage, f => f.Image.PicsumUrl())
                .RuleFor(b => b.Publisher, f => f.Company.CompanyName())
                .RuleFor(b => b.PublicationDate, f => f.Date.Past(10))
                .RuleFor(b => b.CategoryId, f => f.PickRandom(categoryIds))
                .RuleFor(b => b.PageCount, f => f.Random.Number(100, 1000))
                .RuleFor(b => b.ISBN, f => f.Commerce.Ean13());

            return faker.Generate(20); // Generate 20 books
        }
    }
}
