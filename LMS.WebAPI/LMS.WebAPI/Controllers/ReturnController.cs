using AutoMapper;
using LMS.WebAPI.Interfaces;
using LMS.WebAPI.Models;
using LMS.WebAPI.Repositories;
using LMS.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace LMS.WebAPI.Controllers
{

    [Authorize(Roles = "Librarian")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnController : ControllerBase
    {
        public readonly IReturnRepository _returnRepository;
        public readonly IMapper _mapper;
        public ReturnController(IReturnRepository returnRepository, IMapper mapper)
        {
            _returnRepository = returnRepository;
            _mapper = mapper;
        }

        [HttpGet("user-checkouts")]
        public async Task<ActionResult<IEnumerable<CheckoutDto>>> GetUserCheckouts(string? name, string? searchQuery, int pageNumber = 1, int pageSize = 10)
        {
            var (checkouts, paginationMetaData) = await _returnRepository.GetUsersWithCheckedOutBooksAsync(name, pageNumber, pageSize);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetaData));
            var checkoutDtos = _mapper.Map<IEnumerable<CheckoutDto>>(checkouts);

            return Ok(checkoutDtos);
        }

        [HttpGet("checkout-details/{checkoutId}")]
        public async Task<ActionResult<CheckoutDetailDto>> GetCheckoutDetails(int checkoutId)
        {
            var checkoutDetails = await _returnRepository.GetCheckoutDetailsByCheckoutIdAsync(checkoutId);
            var checkoutDetailDtos = _mapper.Map<IEnumerable<CheckoutDetailDto>>(checkoutDetails);
            return Ok(checkoutDetailDtos);
        }

        [HttpPost("return-book/{checkoutDetailId}")]
        public async Task<IActionResult> ReturnBook(int checkoutDetailId)
        {
            try
            {
                await _returnRepository.ReturnBookAsync(checkoutDetailId);
                return Ok("Book returned successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
