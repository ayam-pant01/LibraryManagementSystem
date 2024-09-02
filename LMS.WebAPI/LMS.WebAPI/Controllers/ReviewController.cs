using AutoMapper;
using LMS.WebAPI.Entities;
using LMS.WebAPI.Interfaces;
using LMS.WebAPI.Models;
using LMS.WebAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LMS.WebAPI.Controllers
{
    [Authorize(Roles = "Customer")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;
        public readonly IMapper _mapper;
        public ReviewController(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        [HttpGet("{bookId}")]
        public async Task<ActionResult<ReviewDto>> GetUserReviewForBook(int bookId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return Unauthorized();
            }
            var userReview = await _reviewRepository.GetReviewByBookAndUser(bookId,userId);

            return Ok(_mapper.Map<ReviewDto>(userReview));
        }

        [HttpPut("{bookId}")]
        public async Task<IActionResult> UpdateReview(int bookId, [FromBody] ReviewForCreateAndUpdateDto value)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (userId == null)
                {
                    return Unauthorized();
                }
                var reviewEntity = await _reviewRepository.GetReviewByBookAndUser(bookId, userId);
                if (reviewEntity == null)
                {
                    return NotFound(new { message = $"No review found to update." });
                }
                value.BookId = bookId;
                value.ReviewDate = DateTime.UtcNow;
                _mapper.Map(value, reviewEntity);
                await _reviewRepository.SaveChangesAsync();
                return Ok(new { message = $"Review updated successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "An error occurred while updating the review. Please try again later." });
            }
        }

        [HttpPost]
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
                    return Conflict(new { message = $"A review of selected book already exists. Cannot enter multiple." });
                }
                reviewDto.ReviewDate = DateTime.UtcNow;

                var newReview = _mapper.Map<Review>(reviewDto);
                newReview.UserId = userId;

                await _reviewRepository.AddReviewAsync(newReview);
                await _reviewRepository.SaveChangesAsync();

                return Ok(new { message = $"New review added successfully." });

            }
            catch (Exception ex)
            {

                return BadRequest(new { message = "An error occurred while add the book review. Please try again later." });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int bookId)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (userId == null)
                {
                    return Unauthorized();
                }
                var reviewEntity = await _reviewRepository.GetReviewByBookAndUser(bookId, userId);
                if (reviewEntity == null)
                {
                    return NotFound(new { message = $"No review found to delete." });
                }
                _reviewRepository.DeleteReview(reviewEntity);
                await _reviewRepository.SaveChangesAsync();
                return Ok(new { message = $"Review deleted successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "An error occurred while deleting the review. Please try again later." });
            }
        }
    }
}


