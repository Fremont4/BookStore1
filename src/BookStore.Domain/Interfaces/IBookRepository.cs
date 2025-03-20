using BookStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Interfaces
{
    public interface IBookRepository: IRepository<Book>
    {
        new Task<IEnumerable<Book>> GetAll();
        Task<IEnumerable<Book>> GetBooksByCategory(int categoryId);
        new Task<Book> GetById(int id);
        Task<IEnumerable<Book>> SearchBookByCategory(string searchedValue);
    }
}
