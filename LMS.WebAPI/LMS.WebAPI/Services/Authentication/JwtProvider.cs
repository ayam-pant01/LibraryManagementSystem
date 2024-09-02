using LMS.WebAPI.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LMS.WebAPI.Services.Authentication
{
    public class JwtProvider : IJwtProvider
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _jwtKey;

        public JwtProvider(IConfiguration config)
        {
            _config = config;
            _jwtKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_config["JwtAuthentication:SecretKey"]!));
        }

        public string GenerateToken(AppUser user, IList<string>? userRoles)
        {
            var userClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Email,user.Email!),
                new Claim(ClaimTypes.GivenName,user.FirstName),
                new Claim(ClaimTypes.Surname,user.LastName)
            };
            if (userRoles != null && userRoles.Any())
            {
                userClaims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));
            }
            var credentials = new SigningCredentials(_jwtKey, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(userClaims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = credentials,
                Issuer = _config["JwtAuthentication:Issuer"]
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
