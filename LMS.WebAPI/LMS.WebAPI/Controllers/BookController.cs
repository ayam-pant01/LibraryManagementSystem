using AutoMapper;
using Bogus.DataSets;
using LMS.WebAPI.Entities;
using LMS.WebAPI.Interfaces;
using LMS.WebAPI.Models;
using LMS.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static System.Reflection.Metadata.BlobBuilder;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LMS.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public BookController(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        // GET: api/<BookController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooksAsync(string? title, string? searchQuery, int pageNumber = 1, int pageSize = 10)
        {
            var (bookEntities, paginationMetaData) = await _bookRepository.GetAllBooksAsync(title, searchQuery, pageNumber, pageSize);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetaData));
            var bookDtos = bookEntities.Select(book =>
                            {
                                var bookDto = _mapper.Map<BookDto>(book);
                                bookDto.AverageRating = book.Reviews.Any() ? book.Reviews.Average(r => r.Rating) : 0;
                                return bookDto;
                            }).ToList();

            return Ok(bookDtos);
        }

        // GET api/<BookController>/5
        [HttpGet("{id}", Name = "GetBookByIdAsync")]
        public async Task<ActionResult<BookDto>> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if (book is null)
            {
                return NotFound(new { message = $"Book with the id {id} was not found." });
            }

            var bookDto = _mapper.Map<BookDto>(book);
            bookDto.AverageRating = bookDto.Reviews.Any() ? bookDto.Reviews.Average(r => r.Rating) : 0;
            return Ok(bookDto);
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<IActionResult> CreateBookAsync([FromBody] BookForCreateAndUpdateDto value)
        {
            try
            {

                if (await _bookRepository.CheckBookExistsAsync(value.ISBN))
                {
                    return Conflict(new { message = $"A book with ISBN {value.ISBN} already exists. Cannot enter duplicate." });
                }

                var newBook = _mapper.Map<Book>(value);

                await _bookRepository.AddBookAsync(newBook);
                await _bookRepository.SaveChangesAsync();

                return Ok(new { message = $"Book created successfully." });

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "An error occurred while creating the book. Please try again later." });

            }
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBookAsync(int id, [FromBody] BookForCreateAndUpdateDto value)
        {
            try
            {
                var bookEntity = await _bookRepository.GetBookByIdAsync(id);
                if (bookEntity == null)
                {
                    return NotFound(new { message = $"Book with the id {id} was not found." });
                }
                if (bookEntity.ISBN != value.ISBN && await _bookRepository.CheckBookExistsAsync(value.ISBN))
                {
                    return Conflict(new { message = $"A book with ISBN {value.ISBN} already exists. Cannot enter duplicate." });
                }
                _mapper.Map(value, bookEntity);
                await _bookRepository.SaveChangesAsync();
                return Ok(new { message = $"Book updated successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "An error occurred while updating the book. Please try again later." });
            }
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var bookEntity = await _bookRepository.GetBookByIdAsync(id);
                if (bookEntity == null)
                {
                    return NotFound(new { message = $"Book with the id {id} was not found." });
                }
                _bookRepository.DeleteBook(bookEntity);
                await _bookRepository.SaveChangesAsync();
                return Ok(new { message = $"Book deleted successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "An error occurred while deleting the book. Please try again later." });
            }
        }
    }
}
