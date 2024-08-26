
using LMS.WebAPI.Entities;
using LMS.WebAPI.Models;
using LMS.WebAPI.Services.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace LMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtProvider _jwtProvider;

        public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IJwtProvider jwtProvider)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtProvider = jwtProvider;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var roleManager = await _roleManager.RoleExistsAsync(request.Role);
                if (!roleManager)
                {
                    return BadRequest("Invalid role selection");
                }
                var user = new AppUser
                {
                    Email = request.Email,
                    FirstName = request.FirstName,
                    MiddleName = request.MiddleName,
                    LastName = request.LastName,
                    UserName = request.Email
                };
                var result = await _userManager.CreateAsync(user, request.Password);
                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }
                await _userManager.AddToRoleAsync(user, request.Role);
                return Ok(new AuthResponseDto
                {
                    IsSuccess = true,
                    Message = "User Created Successfully."
                });
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }

        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var user = await _userManager.FindByEmailAsync(request.Email);
                if (user is null)
                {
                    return Unauthorized(new AuthResponseDto
                    {
                        IsSuccess = false,
                        Message = "Invalid username."
                    });

                }

                var  result = await _userManager.CheckPasswordAsync(user, request.Password);
                if (!result)
                {
                    return Unauthorized(new AuthResponseDto
                    {
                        IsSuccess = false,
                        Message = "Invalid Password."
                    });

                }
                string token = _jwtProvider.GenerateToken(user);
                return Ok(new AuthResponseDto
                {
                    IsSuccess = true,
                    Message = "Login Succes.",
                    Token = token
                });
            }
            catch (Exception e)
            {
                return Unauthorized(e.Message);
                //return StatusCode(500, e.Message);
            }
        }
    }
}
