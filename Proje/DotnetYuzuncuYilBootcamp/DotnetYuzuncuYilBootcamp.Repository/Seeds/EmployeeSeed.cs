using DotnetYuzuncuYilBootcamp.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetYuzuncuYilBootcamp.Repository.Seeds
{
    public class EmployeeSeed : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(
                new Employee { Id=1, UserName="gonulkaba", Password="123456", Position="Front-end Developer",Email="gonulkb12@gmail.com",StartedDate=DateTime.Now },
                new Employee { Id=2, UserName="aysecetin", Password="45879545", Position="Back-end Developer",Email="aysecet48@gmail.com",StartedDate=DateTime.Now },
                new Employee { Id=3, UserName="alivelii1", Password="85697452", Position= "Full Stack Developer", Email="velialii98@gmail.com",StartedDate=DateTime.Now }
                );
        }
    }
}
