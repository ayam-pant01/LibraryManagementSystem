using Bogus;
using LMS.WebAPI.Entities;

namespace LMS.WebAPI.DataSeeders
{
    public class CheckoutSeeder
    {
        private static readonly Faker _faker = new Faker();

        public static IEnumerable<Checkout> GenerateCheckouts(
            AppUser user,
            List<Book> books)
        {
            var checkouts = new List<Checkout>();
            var userBooks = books.OrderBy(b => _faker.Random.Number()).ToList(); // Shuffle books to avoid repetition

            int userCheckouts = _faker.Random.Number(3, 5); // Random number of checkouts per user


            for (int i = 0; i < userCheckouts; i++)
            {
                var checkout = new Checkout
                {
                    UserId = user.Id,
                    CheckoutDate = DateTime.UtcNow
                };
                var checkoutDetails = new List<CheckoutDetail>();
                checkouts.Add(checkout);
                int numberOfBooks = _faker.Random.Number(1, 3);
                var checkoutBooks = userBooks.Take(numberOfBooks).ToList();
                userBooks = userBooks.Except(checkoutBooks).ToList(); // Remove used books to avoid repetition

                foreach (var book in checkoutBooks)
                {
                    var checkoutDetail = new CheckoutDetail
                    {
                        BookId = book.BookId
                    };

                    checkoutDetails.Add(checkoutDetail);
                }
                checkout.CheckoutDetails = checkoutDetails;
            }
            return checkouts;
        }
    }

}
