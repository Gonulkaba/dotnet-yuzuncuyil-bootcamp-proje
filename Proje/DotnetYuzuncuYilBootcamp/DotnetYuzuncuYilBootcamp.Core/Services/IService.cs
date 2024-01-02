using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotnetYuzuncuYilBootcamp.Core.Services
{
    public interface IService<T> where T : class
    {
        // Tüm işlemler db de yapılacagı için bu kısımda tüm tanımlamalar Async olmalı.
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);

        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);


        Task UpdateAsync(T entity); 
        Task RemoveAsync(T entity); 
        Task ReomeRangeAsync(IEnumerable<T> entities); 
    }
}
