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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(BookStoreDbContext db, DbSet<Category> dbSet = null) : base(db, dbSet)
        {
        }
    }
}
