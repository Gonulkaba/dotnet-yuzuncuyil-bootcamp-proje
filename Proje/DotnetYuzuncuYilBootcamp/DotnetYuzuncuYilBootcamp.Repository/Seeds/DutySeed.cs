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
    public class DutySeed : IEntityTypeConfiguration<Duty>
    {
        public void Configure(EntityTypeBuilder<Duty> builder)
        {
            builder.HasData(
                new Duty { Id = 1, DutyName = "Veritabanı Güncelleme", Description = "Müşteri talepleri doğrultusunda, mevcut sistemde kullanılan veritabanı güncelleme aracını geliştirme.", Status = "Tamamlanmadı",EmployeeId=1, StartedDate = DateTime.Now },
                new Duty { Id = 2, DutyName = "Performans Optimizasyonu", Description = "Mevcut müşteri mobil uygulamasının performansını artırmak ve kullanıcı deneyimini optimize etmek.", Status = "Tamamlanmadı", EmployeeId = 2, StartedDate = DateTime.Now },
                new Duty { Id = 3, DutyName = "Güvenlik Denetimi", Description = "Web sitenin güvenliğini artırmak ve potansiyel güvenlik açıklarını önlemek için güvenlik denetimi gerçekleştirmek.", Status = "Tamamlanmadı", EmployeeId = 3, StartedDate = DateTime.Now }
               );
        }
    }
}
