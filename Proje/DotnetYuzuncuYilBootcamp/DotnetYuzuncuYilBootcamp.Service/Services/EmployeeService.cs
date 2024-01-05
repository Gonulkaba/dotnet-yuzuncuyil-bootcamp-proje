using DotnetYuzuncuYilBootcamp.Core.Models;
using DotnetYuzuncuYilBootcamp.Core.Repositories;
using DotnetYuzuncuYilBootcamp.Core.Services;
using DotnetYuzuncuYilBootcamp.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetYuzuncuYilBootcamp.Service.Services
{
    public class EmployeeService : Service<Employee>, IEmployeeService
    {
        public EmployeeService(IGenericRepository<Employee> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
