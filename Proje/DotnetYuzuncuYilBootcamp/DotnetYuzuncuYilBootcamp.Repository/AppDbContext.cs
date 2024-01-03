using DotnetYuzuncuYilBootcamp.Core.Models;
using DotnetYuzuncuYilBootcamp.Repository.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DotnetYuzuncuYilBootcamp.Repository
{
    public class AppDbContext : DbContext
    {
        public DbSet<Duty> Duties { get; set; }  
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeProfile> EmployeesProfiles { get; set; }

        //Constructor
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); 
        }
    }
}
