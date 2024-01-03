using DotnetYuzuncuYilBootcamp.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetYuzuncuYilBootcamp.Repository.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            //Fluent API ayarlamaları

            //Primary key ayarlaması
            builder.HasKey(x => x.Id);

            //Primary Key otomatik olarak 1'er 1'er artsın.
            builder.Property(t => t.Id)
                .UseIdentityColumn();

            //maksimum uzunluğu belirleme ve bu alanı zorunlu hale getirme
            builder.Property(t => t.UserName).HasMaxLength(50).IsRequired();
            builder.Property(t => t.Email).HasMaxLength(250).IsRequired();
            builder.Property(t => t.Password).HasMaxLength(150).IsRequired();
            builder.Property(t => t.Position).HasMaxLength(150).IsRequired();


            //Tablo ismini belirleme (Opsiyon) 
            builder.ToTable("Employees");
        }
    }
}
