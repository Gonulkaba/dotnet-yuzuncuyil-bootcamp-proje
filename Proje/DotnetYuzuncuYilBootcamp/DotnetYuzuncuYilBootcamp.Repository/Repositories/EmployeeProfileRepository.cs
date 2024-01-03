using DotnetYuzuncuYilBootcamp.Core.Models;
using DotnetYuzuncuYilBootcamp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetYuzuncuYilBootcamp.Repository.Repositories
{
    public class EmployeeProfileRepository: GenericRepository<EmployeeProfile>,IEmployeeProfileRepository
    {
        public EmployeeProfileRepository(AppDbContext context) : base(context)
        {
        }
    }
}
