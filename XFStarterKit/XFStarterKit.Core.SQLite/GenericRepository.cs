using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace XFStarterKit.Core.SQLite
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        private BSMContext _context;

        public GenericRepository()
        {
            _context = new BSMContext();
        }

        public async Task<int> Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Delete(string id)
        {
            var entity = await Get(id);
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync();
        }


        public async Task<List<T>> Get() => await _context.Set<T>().ToListAsync();

        public async Task<T> Get(string id) => await _context.FindAsync<T>(id);

        public async Task<List<T>> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null)
        {
            var query = _context.Set<T>().AsQueryable();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                query = query.OrderBy(orderBy);
            }

            return await query.ToListAsync();
        }

        public async Task<T> Get(Expression<Func<T, bool>> predicate) => await _context.Set<T>().Where(predicate).FirstOrDefaultAsync();

        public async Task<T> Get(int id) => await _context.FindAsync<T>(id);


        public async Task<List<T>> GetAll(Expression<Func<T, bool>> predicate) => await _context.Set<T>().Where(predicate).ToListAsync();

        public async Task<int> GetCount(Expression<Func<T, bool>> predicate)
        {
            var query = _context.Set<T>();
            if (predicate != null)
            {
                return await query.CountAsync(predicate);
            }

            return await Task.FromResult(-1);
        }

        public async Task<T> GetFirstItem()
        {
            return await _context.Set<T>().FirstOrDefaultAsync();
        }

        public async Task<int> Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
                return await _context.SaveChangesAsync(); ;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
