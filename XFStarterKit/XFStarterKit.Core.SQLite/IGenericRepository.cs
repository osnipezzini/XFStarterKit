using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace XFStarterKit.Core.SQLite
{
    public interface IGenericRepository<T> where T : class, new()
    {
        Task<List<T>> Get();
        Task<List<T>> GetAll(Expression<Func<T, bool>> predicate);
        Task<T> Get(int id);
        Task<List<T>> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null);
        Task<T> Get(Expression<Func<T, bool>> predicate);
        Task<int> Insert(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(T entity);
        Task<int> GetCount(Expression<Func<T, bool>> predicate);
        Task<T> GetFirstItem();
    }
}
