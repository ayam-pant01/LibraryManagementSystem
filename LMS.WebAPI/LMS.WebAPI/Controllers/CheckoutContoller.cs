using Azure.Core;
using LMS.WebAPI.Interfaces;
using LMS.WebAPI.Models;
using LMS.WebAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LMS.WebAPI.Controllers
{
    [Authorize(Roles = "Customer")]
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutContoller : ControllerBase
    {
        private readonly ICheckoutRepository _checkoutRepository;
        public CheckoutContoller(ICheckoutRepository checkoutRepository)
        {
            _checkoutRepository = checkoutRepository;
        }

        // POST api/<CheckoutContoller>
        [HttpPost]
        public async Task<IActionResult> CheckoutBooks([FromBody] CheckoutRequestDto value)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return Unauthorized();
            }

            if (value == null || !value.BookIds.Any())
            {
                return BadRequest(new { message = "Invalid request data" });
            }
            try
            {
                await _checkoutRepository.CheckoutBooksAsync(userId, value.BookIds);
                return Ok(new { message = $"Books checked out successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
