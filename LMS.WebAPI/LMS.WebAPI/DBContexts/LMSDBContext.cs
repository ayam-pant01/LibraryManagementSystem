﻿using Bogus;
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

        modelBuilder.Entity<CheckoutDetail>()
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

        modelBuilder.Entity<CheckoutDetail>()
           .HasOne(cd => cd.Book)
           .WithMany(b => b.CheckoutDetails)
           .HasForeignKey(cd => cd.BookId);

        // lookinto cases for delete of data - Delete behavior - restrict/cascade

        //adding index to bookid and returnedDate of CheckoutDetail - got an idea to add index while checking the book is returned.
        modelBuilder.Entity<CheckoutDetail>()
            .HasIndex(cd => new { cd.BookId, cd.ReturnedDate });

        //adding an unique constraint for review of book on bookid and user id
        modelBuilder.Entity<Review>()
            .HasIndex(r => new { r.BookId, r.UserId })
            .IsUnique();


    }
}
