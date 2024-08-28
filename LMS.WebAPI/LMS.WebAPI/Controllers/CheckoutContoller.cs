using Azure.Core;
using LMS.WebAPI.Interfaces;
using LMS.WebAPI.Models;
using LMS.WebAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutContoller : ControllerBase
    {
        private readonly ICheckoutRepository _checkoutRepository;
        public CheckoutContoller(ICheckoutRepository checkoutRepository)
        {
            _checkoutRepository = checkoutRepository;
        }

        [Authorize(Roles = "Customer")]
        [HttpGet("customer-role")]
        public async Task<IActionResult> TestCustomerRole()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return Unauthorized();
            }
            return Ok("Customer role accessed!" + userId);
        }

        [Authorize(Roles = "Librarian")]
        [HttpGet("librarian-role")]
        public async Task<IActionResult> TestLibrarianRole()
        {
            // Retrieve the user ID from the claims
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return Unauthorized();
            }
            return Ok("Librarian role accessed!" + userId);
        }

        // POST api/<CheckoutContoller>
        [Authorize(Roles = "Customer")]
        [HttpPost]
        public async Task<IActionResult> CheckoutBooks([FromBody] CheckoutRequestDto value)
        {
            // Retrieve the user ID from the claims
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return Unauthorized();
            }

            if (value == null || !value.BookIds.Any())
            {
                return BadRequest("Invalid request data");
            }
            try
            {
                // Perform the checkout operation
                await _checkoutRepository.CheckoutBooksAsync(userId, value.BookIds);
                return Ok("Books checked out successfully.");
            }
            catch (Exception ex)
            {
                // Handle exceptions and return user-friendly messages
                return BadRequest(ex.Message);
            }
        }
    }
}
