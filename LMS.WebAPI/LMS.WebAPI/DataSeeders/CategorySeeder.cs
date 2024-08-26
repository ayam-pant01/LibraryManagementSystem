using Bogus;
using LMS.WebAPI.Entities;

namespace LMS.WebAPI.DataSeeders
{
    public class CategorySeeder
    {
        public static IEnumerable<Category> GenerateCategories()
        {
            var id = 1;
            var faker = new Faker<Category>()
                .RuleFor(b => b.CategoryId, f => id++)
                .RuleFor(c => c.Name, f => f.Commerce.Categories(1)[0]);

            return faker.Generate(5); // Generate 5 categories
        }
    }
}
