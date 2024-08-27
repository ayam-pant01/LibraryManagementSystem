using AutoMapper;
using Bogus.DataSets;
using LMS.WebAPI.Entities;
using LMS.WebAPI.Interfaces;
using LMS.WebAPI.Models;
using LMS.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
            return Ok(_mapper.Map<IEnumerable<BookDto>>(bookEntities));
        }

        // GET api/<BookController>/5
        [HttpGet("{id}", Name = "GetBookByIdAsync")]
        public async Task<ActionResult<BookDto>> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if (book is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<BookDto>(book));
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<ActionResult<BookDto>> CreateBookAsync([FromBody] BookForCreateAndUpdateDto value)
        {
            if (await _bookRepository.CheckBookExistsAsync(value.ISBN))
            {
                return Conflict(new { message = $"A book with ISBN {value.ISBN} already exists. Cannot enter duplicate." });
            }

            var newBook = _mapper.Map<Book>(value);

            await _bookRepository.AddBookAsync(newBook);
            await _bookRepository.SaveChangesAsync();

            var createdBook = _mapper.Map<BookDto>(newBook);

            return CreatedAtRoute("GetBookByIdAsync",
                new
                {
                    id = createdBook.BookId
                },
                createdBook);
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBookAsync(int id, [FromBody] BookForCreateAndUpdateDto value)
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
            return NoContent();
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var bookEntity = await _bookRepository.GetBookByIdAsync(id);
            if (bookEntity == null)
            {
                return NotFound(new { message = $"Book with the id {id} was not found." });
            }
            _bookRepository.DeleteBook(bookEntity);
            await _bookRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}
