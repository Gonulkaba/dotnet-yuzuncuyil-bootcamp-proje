using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotnetYuzuncuYilBootcamp.Core.Repositories
{
    public interface IGenericRepository<T> where T : class     
    {
        //Async : uzun süreli işlemlerde var olan thread leri bloklamamak için kullanılıyor. Async metotlar vt ye gider.
        Task<T> GetByIdAsync(int id);  //Id ile tüm verileri model olarak döner.

        IQueryable<T> GetAll(); //Queryable, verileri bellekten getirir. ToList() dendiğinde veri tabanına gider.

        //Filtreleme yapmak için expression parametresini function delege olarak tanımlanması gerekir.
        IQueryable<T> Where(Expression<Func<T, bool>> expression);

        Task AddAsync(T entity);

        //Birden fazla kayıt ekleye bilmek.
        Task AddRangeAsync(IEnumerable<T> entities);

        //Güncelleme ve silme işlemleri vt de yapılmaz stage üzerinde yapılır, async olmasına gerek yok.
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
