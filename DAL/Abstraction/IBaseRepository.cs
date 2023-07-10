using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstraction
{
    public interface IBaseRepository<T>
    {
        Task Create(T item);
        Task<T> FindAsyncById(Guid id);
        Task<IEnumerable<T>> GetAsync();
        Task<T> FindAsyncById(Guid Id, params Expression<Func<T, object>>[] includes);
        Task<IQueryable<T>> GetAll(params Expression<Func<T, object>>[] includes);
        Task Remove(T item);
        Task Update(T item);
    }
}
