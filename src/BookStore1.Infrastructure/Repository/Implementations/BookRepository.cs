using BookStore.Domain.Interfaces;
using BookStore.Domain.Models;
using BookStore1.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore1.Infrastructure.Repository.Implementations
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(BookStoreDbContext db, DbSet<Book> dbSet = null) : base(db, dbSet)
        {
        }
        public override async Task<IEnumerable<Book>> GetAll()
        {
            return await Db.Books.AsNoTracking().Include(b => b.Category)
                .OrderBy(b => b.Name).ToListAsync();
        }

        public override async Task<Book> GetById(int id)
        {
            return await Db.Books.AsNoTracking().Include(b => b.Category)
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Book>> GetBooksByCategory(int categoryId)
        {
            return await Search(b => b.CategoryId == categoryId);
        }

        public async Task<IEnumerable<Book>> SearchBookByCategory(string searchedValue)
        {
            return await Db.Books.AsNoTracking()
                .Include(b => b.Category)
                .Where(b => b.Name.Contains(searchedValue) ||
                            b.Author.Contains(searchedValue) ||
                            b.Description.Contains(searchedValue) ||
                            b.Category.Name.Contains(searchedValue))
                .ToListAsync();
        }
    }
}
