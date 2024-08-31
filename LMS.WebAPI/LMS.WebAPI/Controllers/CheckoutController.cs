using AutoMapper;
using LMS.WebAPI.Entities;
using LMS.WebAPI.Interfaces;
using LMS.WebAPI.Models;
using LMS.WebAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace LMS.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly ICheckoutRepository _checkoutRepository;
        private readonly IReviewRepository _reviewRepository;
        public readonly IMapper _mapper;
        public CheckoutController(ICheckoutRepository checkoutRepository, IMapper mapper, IReviewRepository reviewRepository)
        {
            _checkoutRepository = checkoutRepository;
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        [Authorize(Roles = "Customer")]
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



        [Authorize(Roles = "Librarian")]
        [HttpGet("{checkoutId}")]
        public async Task<ActionResult<CheckoutDetailDto>> GetCheckoutDetails(int checkoutId)
        {
            var checkoutDetails = await _checkoutRepository.GetCheckoutDetailsByCheckoutIdAsync(checkoutId);
            var checkoutDetailDtos = _mapper.Map<IEnumerable<CheckoutDetailDto>>(checkoutDetails);
            return Ok(checkoutDetailDtos);
        }



        [Authorize(Roles = "Librarian")]
        [HttpGet("user-checkouts")]
        public async Task<ActionResult<IEnumerable<CheckoutDto>>> GetUserCheckouts(string? name, string? searchQuery, int pageNumber = 1, int pageSize = 10)
        {
            var (checkouts, paginationMetaData) = await _checkoutRepository.GetUsersWithCheckedOutBooksAsync(name, pageNumber, pageSize);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetaData));
            var checkoutDtos = _mapper.Map<IEnumerable<CheckoutDto>>(checkouts);

            return Ok(checkoutDtos);
        }

        // POST api/<CheckoutContoller>
        [Authorize(Roles = "Customer")]
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


        [Authorize(Roles = "Customer")]
        [HttpGet("user-book")]
        public async Task<ActionResult<ReviewDto>> GetUserReview()
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


        [Authorize(Roles = "Customer")]
        [HttpPost("review-book")]
        public async Task<IActionResult> ReviewBook([FromBody] ReviewForCreateAndUpdateDto reviewDto)
        {
            try
            {

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (userId == null)
                {
                    return Unauthorized();
                }

                if (await _reviewRepository.CheckReviewExists(reviewDto.BookId, userId))
                {
                    return Conflict(new { message = $"A review selected book already exists. Cannot enter multiple." });
                }

                var newReview = _mapper.Map<Review>(reviewDto);

                await _reviewRepository.AddReviewAsync(newReview);
                await _reviewRepository.SaveChangesAsync();

                return Ok(new { message = $"New review added successfully." });

            }
            catch (Exception ex)
            {

                return BadRequest(new { message = "An error occurred while add the book review. Please try again later." });
            }
        }
    }
}
