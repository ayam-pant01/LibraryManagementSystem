using Microsoft.AspNetCore.Identity;

namespace LMS.WebAPI.DataSeeders
{
    public class RoleSeeder
    {
        public static IEnumerable<IdentityRole> GenerateRoles()
        {
            var roles = new List<IdentityRole>
            {
                new IdentityRole { Name = "Librarian", NormalizedName = "LIBRARIAN" },
                new IdentityRole { Name = "Customer", NormalizedName = "CUSTOMER" }
            };

            return roles;
        }
    }
}
