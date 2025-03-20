using BookStore.Domain.Interfaces;
using BookStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Services.Implementation
{
    public class BookServices: IBookService
    {
        private readonly IBookRepository _bookRepository;

        private readonly IBookService _bookService;

        public BookServices(IBookRepository bookRepository, IBookService bookService = null)
        {
            _bookRepository = bookRepository;
            _bookService = bookService;
        }

        public async Task<Book> Add(Book book)
        {
            var searchBook = await _bookRepository.Search(c => c.Name == book.Name);
            if (searchBook.Any())
            {
                return null;
            }
            await _bookRepository.Add(book);
            return book;
        }

        public void Dispose()
        {
            _bookRepository?.Dispose();
        }

        public Task<IEnumerable<Book>> GetAll()
        {
            return _bookRepository.GetAll();
        }

        public Task<IEnumerable<Book>> GetBookByCategory(int categoryId)
        {
            return _bookRepository.GetBooksByCategory(categoryId);
        }

        public Task<Book> GetById(int id)
        {
            return _bookRepository.GetById(id);
        }

        public async  Task<bool> Remove(Book book)
        {
            await _bookRepository.Remove(book);
            return true;
        }

        public Task<IEnumerable<Book>> Search(string bookName)
        {
            var searchBook = _bookRepository.Search(c => c.Name.Contains(bookName));
            return searchBook;
        }

        public Task<IEnumerable<Book>> SearchBookByCategory(string searchedValue)
        {
            return _bookRepository.SearchBookByCategory(searchedValue);
        }

        public async Task<Book> Update(Book book)
        {
            var existingBooks = await _bookRepository.Search(c => c.Name == book.Name && c.Id != book.Id);
            if (existingBooks.Any())
            {
                return null;
            }
            await _bookRepository.Update(book);
            return book;
        }
    }
}
