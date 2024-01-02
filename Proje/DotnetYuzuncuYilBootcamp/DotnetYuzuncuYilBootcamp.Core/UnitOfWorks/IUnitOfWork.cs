using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetYuzuncuYilBootcamp.Core.UnitOfWorks
{
    //Bir tasarım deseni olup genellikle bir veritabanı işlem sürecini tek bir işlem (transaction) olarak ele almak ve bu süreci yönetmek için kullanılır.
    public interface IUnitOfWork
    {
        Task CommitAsync();
        void Commit();
    }
}
