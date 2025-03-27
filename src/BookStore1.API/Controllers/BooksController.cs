using AutoMapper;
using BookStore.Domain.Interfaces;
using BookStore.Domain.Models;
using BookStore1.API.DTOs.Book;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : MainController
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BooksController(IBookService bookService, IMapper mapper = null)
        {
            _bookService = bookService;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult>GetAll()
        {
            var books = await _bookService.GetAll();
            return Ok(_mapper.Map<IEnumerable<BookResultDtos>>(books));
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _bookService.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<BookResultDtos>(book));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add(BookAddDtos bookAddDtos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var book = _mapper.Map<Book>(bookAddDtos);
            var boolResult = await _bookService.Add(book);
            if (boolResult == null)
            {
                return BadRequest();
            }
            return Ok(_mapper.Map<BookResultDtos>(boolResult));
        }
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, BookAddDtos bookAddDtos)
        {
            if (id != bookAddDtos.CategoryId)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _bookService.Update(_mapper.Map<Book>(bookAddDtos));
            return Ok(bookAddDtos);
        }
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Remove(int id)
        {
            var book = await _bookService.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            await _bookService.Remove(book);
            return Ok();
        }
        [HttpGet("category/{categoryId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBookByCategory(int categoryId)
        {
            var books = await _bookService.GetBookByCategory(categoryId);
            if (books == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<BookResultDtos>>(books));
        }
        [HttpGet("search_value/{searchedValue}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SearchBookByCategory(string searchedValue)
        {
            var books = await _bookService.SearchBookByCategory(searchedValue);
            if (books == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<BookResultDtos>>(books));
        }
        [HttpGet("search/{bookName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Search(string bookName)
        {
            var books = await _bookService.Search(bookName);
            if (books == null || !books.Any())
            {
                return NotFound("None book was found");
            }
            return Ok(_mapper.Map<IEnumerable<BookResultDtos>>(books));
        }

    }
}
