using Bogus;
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
    public DbSet<CheckoutDetail> CheckoutDetails { get; set; }
    public DbSet<Review> Reviews { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Book>()
            .Property(p => p.RowVersion)
            .IsRowVersion();

        modelBuilder.Entity<Book>()
          .HasOne(b => b.Category)
          .WithMany(c => c.Books)
          .HasForeignKey(b => b.CategoryId);

        modelBuilder.Entity<Checkout>()
            .HasMany(c => c.CheckoutDetails)
            .WithOne(cd=>cd.Checkout)
            .HasForeignKey(cd => cd.CheckoutId);

        modelBuilder.Entity<Book>()
              .HasMany(b => b.Reviews)
              .WithOne(r => r.Book)
              .HasForeignKey(r => r.BookId);

        modelBuilder.Entity<CheckoutDetail>()
            .HasOne(cd=>cd.Checkout)
            .WithMany(c=>c.CheckoutDetails)
            .HasForeignKey(cd=>cd.CheckoutId);
        //    .OnDelete(DeleteBehavior.Cascade); // look into on delete behavior

        modelBuilder.Entity<CheckoutDetail>()
           .HasOne(cd => cd.Book)
           .WithMany(b => b.CheckoutDetails)
           .HasForeignKey(cd => cd.BookId);
        //   .OnDelete(DeleteBehavior.Restrict); // look into on delete behavior

        //var roles = RoleSeeder.GenerateRoles();
        //modelBuilder.Entity<IdentityRole>().HasData(roles);
        //var categories = CategorySeeder.GenerateCategories();
        //modelBuilder.Entity<Category>().HasData(categories);
        //var books = BookSeeder.GenerateBooks();
        //modelBuilder.Entity<Book>().HasData(books);

    }
}
