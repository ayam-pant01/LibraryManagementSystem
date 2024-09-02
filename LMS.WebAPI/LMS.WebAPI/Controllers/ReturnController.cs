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

        [HttpPut("return-book/{checkoutDetailId}")]
        public async Task<IActionResult> ReturnBook(int checkoutDetailId)
        {
            try
            {
                await _returnRepository.ReturnBookAsync(checkoutDetailId);
                return Ok(new { message = $"Book returned successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


    }
}
