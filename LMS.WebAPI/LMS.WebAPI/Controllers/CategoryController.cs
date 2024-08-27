using AutoMapper;
using LMS.WebAPI.Entities;
using LMS.WebAPI.Interfaces;
using LMS.WebAPI.Models;
using LMS.WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}", Name = "GetCategoryByIdAsync")]
        public async Task<ActionResult<CategoryDto>> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CategoryDto>(category));
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<ActionResult<CategoryDto>> CreateCategoryAsync([FromBody] CategoryDto value)
        {

            var newCategory = _mapper.Map<Category>(value);

            await _categoryRepository.AddCategoryAsync(newCategory);
            await _categoryRepository.SaveChangesAsync();

            var createdCategory = _mapper.Map<CategoryDto>(newCategory);

            return CreatedAtRoute("GetCategoryByIdAsync",
                new
                {
                    id = createdCategory.CategoryId
                },
                createdCategory);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategoryAsync(int id, [FromBody] CategoryDto value)
        {
            var categoryEntity = await _categoryRepository.GetCategoryByIdAsync(value.CategoryId);
            if (categoryEntity == null)
            {
                return NotFound(new { message = $"Category with the id {id} was not found." });
            }
            _mapper.Map(value, categoryEntity);
            await _categoryRepository.SaveChangesAsync();
            return NoContent();
        }

    }
}
