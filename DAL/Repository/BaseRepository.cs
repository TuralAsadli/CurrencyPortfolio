using DAL.Abstraction;
using DAL.DAL;
using DAL.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    internal class BaseRepository<T> : IBaseRepository<T> where T : BaseItem
    {
        AppDbContext _context;
        DbSet<T> _dbSet;


        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }


        public async Task Create(T item)
        {
            _dbSet.Add(item);
            await Save();
        }

        public async Task<T> FindAsyncById(Guid id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T> FindAsyncById(Guid Id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet.AsNoTracking();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(e => e.Id == Id);
        }

        public async Task<IQueryable<T>> GetAll(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query;
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public async Task<IEnumerable<T>> GetAsync(Func<T, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public async Task Remove(T item)
        {
            _dbSet.Remove(item);
            await Save();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await Save();
        }
    }
}
