using AutoMapper;
using BookStore.Domain.Interfaces;
using BookStore.Domain.Models;
using BookStore1.API.DTOs.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : MainController
    {
        private readonly ICategoryService _categoryService;

        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper = null)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAll();
            return Ok(_mapper.Map<IEnumerable<CategoryResultDtos>>(categories));
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CategoryResultDtos>(category));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add(CategoryAddDtos categoryAddDtos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var category = _mapper.Map<Category>(categoryAddDtos);
            var categoryResult = await _categoryService.Add(category);
            if (categoryResult == null)
            {
                return BadRequest();
            }
            return Ok(_mapper.Map<CategoryResultDtos>(categoryResult));
        }
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, CategoryEditDtos categoryUpdateDtos)
        {
            if (id != categoryUpdateDtos.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _categoryService.Update(_mapper.Map<Category>(categoryUpdateDtos));
            return Ok(categoryUpdateDtos);
        }
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Remove(int id)
        {
            var category = await _categoryService.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            var result = await _categoryService.Remove(category);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpGet("search/{categoryName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Search(string categoryName)
        {
            var categories = await _categoryService.Search(categoryName);
            if (categories == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<CategoryResultDtos>>(categories));
        }   

    }
}
