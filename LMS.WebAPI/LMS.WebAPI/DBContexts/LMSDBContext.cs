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
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var roles = RoleSeeder.GenerateRoles();
        modelBuilder.Entity<IdentityRole>().HasData(roles);
    }
}
