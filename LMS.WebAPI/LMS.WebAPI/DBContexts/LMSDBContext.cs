using LMS.WebAPI.DataSeeders;
using LMS.WebAPI.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LMS.WebAPI.DBContexts;

public class LMSDBContext : IdentityDbContext<AppUser>
{
    public LMSDBContext(DbContextOptions<LMSDBContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Checkout> Checkouts { get; set; }
    public DbSet<Review> Reviews { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
     
        modelBuilder.Entity<Book>()
          .HasOne(b => b.Category)
          .WithMany(c => c.Books)
          .HasForeignKey(b => b.CategoryId);

        modelBuilder.Entity<Checkout>()
            .HasOne(c => c.Book)
            .WithMany(b => b.Checkouts)
            .HasForeignKey(c => c.BookId);

        var roles = RoleSeeder.GenerateRoles();
        modelBuilder.Entity<IdentityRole>().HasData(roles);
        var categories = CategorySeeder.GenerateCategories();
        modelBuilder.Entity<Category>().HasData(categories);
        var books = BookSeeder.GenerateBooks();
        modelBuilder.Entity<Book>().HasData(books);

    }
}
