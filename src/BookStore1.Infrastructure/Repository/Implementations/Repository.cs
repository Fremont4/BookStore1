using BookStore.Domain.Interfaces;
using BookStore1.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookStore1.Infrastructure.Repository.Implementations
{
    public abstract class Repository<TEntity>: IRepository<TEntity> where TEntity : class
    {
        protected readonly BookStoreDbContext Db;
        protected readonly DbSet<TEntity> DbSet;
        protected Repository(BookStoreDbContext db, DbSet<TEntity> dbSet = null)
        {
            Db = db;
            DbSet = dbSet;
        }

        public virtual async Task Add(TEntity entity)
        {
            DbSet.Add(entity);
            await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            var entity = await DbSet.FindAsync(id).AsTask();
            return entity ?? throw new InvalidOperationException("Entity not found");
        }

        public virtual async Task Remove(TEntity entity)
        {
            DbSet.Remove(entity);
            await Db.SaveChangesAsync();
        }

        public Task<int> SaveChanges()
        {
            return Db.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

        public async Task Update(TEntity entity)
        {
            DbSet.Update(entity);
            await Db.SaveChangesAsync();
        }
    }
}
