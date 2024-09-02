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
            var availableBooks = books.OrderBy(b => _faker.Random.Number()).ToList(); 

            int userCheckouts = _faker.Random.Number(3, 5); 


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
                var checkoutBooks = availableBooks.Take(numberOfBooks).ToList();
                availableBooks = availableBooks.Except(checkoutBooks).ToList(); 

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
