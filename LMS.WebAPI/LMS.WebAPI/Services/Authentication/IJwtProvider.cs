using LMS.WebAPI.Entities;

namespace LMS.WebAPI.Services.Authentication
{
    public interface IJwtProvider
    {
        string GenerateToken(AppUser user);
    }
}
