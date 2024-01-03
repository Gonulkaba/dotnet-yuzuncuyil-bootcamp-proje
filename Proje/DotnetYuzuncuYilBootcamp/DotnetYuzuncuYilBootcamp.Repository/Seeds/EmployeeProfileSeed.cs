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
    internal class EmployeeProfileSeed : IEntityTypeConfiguration<EmployeeProfile>
    {
        public void Configure(EntityTypeBuilder<EmployeeProfile> builder)
        {
            builder.HasData(
                new EmployeeProfile {Id=1,FirstName="Gönül",LastName="Kaba",Phone="05978456895",Address="Düzce/Merkez", EmployeeId=1 },
                new EmployeeProfile {Id=2,FirstName="Ayşe",LastName="Çetin",Phone="05768459212",Address="Ankara/Merkez", EmployeeId=2 },
                new EmployeeProfile {Id=3,FirstName="Ali",LastName="Veli",Phone="05632165498",Address="Mersin/Merkez", EmployeeId=3 }
                );
        }
    }
}
