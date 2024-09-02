using Azure.Core;
using Bogus;
using LMS.WebAPI.DBContexts;
using LMS.WebAPI.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LMS.WebAPI.DataSeeders
{
    public class DataSeeder
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly LMSDBContext _context;
        private static readonly Faker _faker = new Faker();

        public DataSeeder(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, LMSDBContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public async Task SeedAsync()
        {
            await SeedRolesAsync();
            await SeedUsersAsync();
            await SeedCategoriesAsync();
            await SeedBooksAsync();
            await SeedCheckoutAsync();
            await SeedReturnAsync();
        }

        private async Task SeedRolesAsync()
        {

            if (!await _roleManager.Roles.AnyAsync())
            {

                var roleList = RoleSeeder.GenerateRoles();
                foreach (var item in roleList)
                {
                    if (!await _roleManager.RoleExistsAsync(item.Name))
                    {
                        await _roleManager.CreateAsync(item);

                    }
                }
            }
        }

        private async Task SeedUsersAsync()
        {
            if (!await _userManager.Users.AnyAsync())
            {
                var librarianUser = new AppUser
                {
                    Email = "librarian@lms.com",
                    FirstName = "Librarian",
                    LastName = "User",
                    UserName = "librarian@lms.com"
                };

                var customerUser = new AppUser
                {
                    Email = "customer@lms.com",
                    FirstName = "Customer",
                    LastName = "User",
                    UserName = "customer@lms.com"
                };

                var password = "Password123!";

                await CreateUserAsync(librarianUser, password, "Librarian");
                await CreateUserAsync(customerUser, password, "Customer");
            }
        }

        private async Task CreateUserAsync(AppUser user, string password, string role)
        {
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }

                await _userManager.AddToRoleAsync(user, role);
            }
            else
            {
                throw new InvalidOperationException($"Failed to create user: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }
        }

        private async Task SeedCategoriesAsync()
        {
            if (!_context.Categories.Any())
            {
                var cateogiesList = CategorySeeder.GenerateCategories();
                await _context.Categories.AddRangeAsync(cateogiesList);
                await _context.SaveChangesAsync();
            }
        }

        private async Task SeedBooksAsync()
        {
            if (!_context.Books.Any())
            {
                var categoryList = await _context.Categories.Select(x => x.CategoryId).Distinct().ToListAsync();
                if (categoryList.Any())
                {
                    var bookList = BookSeeder.GenerateBooks(categoryList);
                    await _context.Books.AddRangeAsync(bookList);
                    await _context.SaveChangesAsync();
                }
            }
        }
        private async Task SeedCheckoutAsync()
        {
            if (!_context.Checkouts.Any())
            {
                var books = _context.Books.Where(b => b.IsAvailable).ToList();
                var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == "customer@lms.com");
                if (user != null)
                {
                    var checkouts = CheckoutSeeder.GenerateCheckouts(user, books);

                    await _context.Checkouts.AddRangeAsync(checkouts);
                    await _context.SaveChangesAsync();


                    var allCheckoutDetails = checkouts.SelectMany(c => c.CheckoutDetails).ToList();


                    var bookIds = allCheckoutDetails.Select(cd => cd.BookId).Distinct().ToList();
                    var booksToUpdate = await _context.Books.Where(b => bookIds.Contains(b.BookId)).ToListAsync();

                    foreach (var book in booksToUpdate)
                    {
                        book.IsAvailable = false;
                    }
                    _context.Books.UpdateRange(books);
                    await _context.SaveChangesAsync();
                }
            }
        }

        private async Task SeedReturnAsync()
        {
            if (_context.CheckoutDetails.Any())
            {
                var checkoutList = _context.CheckoutDetails.Where(b => b.ReturnedDate == null).ToList();
                if (checkoutList.Any())
                {
                    int numberOfBooksReturned = _faker.Random.Number(1, checkoutList.Count);

                    var randomCheckouts = checkoutList
                       .OrderBy(x => _faker.Random.Number())
                       .Take(numberOfBooksReturned)
                       .ToList();

                    foreach (var checkout in randomCheckouts)
                    {
                        checkout.ReturnedDate = DateTime.UtcNow;

                        var book = await _context.Books
                            .FirstOrDefaultAsync(b => b.BookId == checkout.BookId);

                        if (book != null)
                        {
                            book.IsAvailable = true;
                        }
                    }
                    await _context.SaveChangesAsync();
                    var booksReturned = randomCheckouts.Select(x => x.BookId).ToList();
                    if (booksReturned.Any())
                    {
                        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == "customer@lms.com");
                        if (user != null)
                        {
                            var reviewList = ReviewSeeder.GenerateReviews(booksReturned, user.Id);
                            await _context.Reviews.AddRangeAsync(reviewList);
                            await _context.SaveChangesAsync();
                        }
                    }

                }
            }
        }
    }
}
