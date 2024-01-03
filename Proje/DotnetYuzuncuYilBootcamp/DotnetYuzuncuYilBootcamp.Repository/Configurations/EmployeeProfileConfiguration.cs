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
    public class EmployeeProfileConfiguration : IEntityTypeConfiguration<EmployeeProfile>
    {
        public void Configure(EntityTypeBuilder<EmployeeProfile> builder)
        {
            //Fluent API ayarlamaları

            //Primary key ayarlaması
            builder.HasKey(x => x.Id);

            //Primary Key otomatik olarak 1'er 1'er artsın.
            builder.Property(t => t.Id)
                .UseIdentityColumn();

            //maksimum uzunluğu belirleme ve bu alanı zorunlu hale getirme
            builder.Property(t => t.FirstName).HasMaxLength(150).IsRequired();
            builder.Property(t => t.LastName).HasMaxLength(150).IsRequired();
            builder.Property(t => t.Phone).HasMaxLength(11).IsRequired();
            builder.Property(t => t.Address).HasMaxLength(250).IsRequired();

            //Tablo ismini belirleme (Opsiyon) 
            builder.ToTable("EmployeesProfiles");
        }
    }
}
