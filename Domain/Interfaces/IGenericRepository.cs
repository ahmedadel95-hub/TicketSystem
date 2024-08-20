using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetAllAsync(bool tracked = true);
        IQueryable<T> GetAsync(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "", int? pageSize = 0, int? pageNumber = 0);
        Task<T> GetFirstAsync(Expression<Func<T, bool>> expression);
        Task<int> UpdateAsync(T entity);
        Task DeleteByIdAsync(int id);
        Task<int> SaveAsync();
    }
}
