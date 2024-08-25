using LMS.WebAPI.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LMS.WebAPI.DBContexts;

public class LMSDBContext: IdentityDbContext<AppUser>
{
    public LMSDBContext(DbContextOptions<LMSDBContext> options) : base(options)
    {

    }
}
