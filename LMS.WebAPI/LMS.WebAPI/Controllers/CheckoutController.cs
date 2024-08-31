using AutoMapper;
using LMS.WebAPI.Interfaces;
using LMS.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LMS.WebAPI.Controllers
{
    [Authorize(Roles = "Customer")]
    [Route("api/[controller]")]
    [ApiController]
    public class  CheckoutController : ControllerBase
    {
        private readonly ICheckoutRepository _checkoutRepository;
        public readonly IMapper _mapper;
        public CheckoutController(ICheckoutRepository checkoutRepository, IMapper mapper)
        {
            _checkoutRepository = checkoutRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserCheckoutDto>>> GetUserCheckouts()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return Unauthorized();
            }
            var checkouts = await _checkoutRepository.GetUserCheckoutListAsync(userId);
            var checkoutDtos = _mapper.Map<IEnumerable<UserCheckoutDto>>(checkouts);

            return Ok(checkoutDtos);
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
