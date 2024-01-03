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
    public class DutyConfiguration : IEntityTypeConfiguration<Duty>
    {
        public void Configure(EntityTypeBuilder<Duty> builder)
        {
            //Fluent API ayarlamaları

            //Primary key ayarlaması
            builder.HasKey(x => x.Id);

            //Primary Key otomatik olarak 1'er 1'er artsın.
            builder.Property(t => t.Id)
                .UseIdentityColumn();

            //Maksimum uzunluğu belirleme ve alanı zorunlu hale getirme
            builder.Property(t => t.DutyName).HasMaxLength(100).IsRequired();
            builder.Property(t => t.Description).HasMaxLength(350).IsRequired();
            builder.Property(t => t.Status).HasMaxLength(50).IsRequired();

            //Tablo ismini belirleme (Opsiyon) 
            builder.ToTable("Duties");
        }
    }
}
