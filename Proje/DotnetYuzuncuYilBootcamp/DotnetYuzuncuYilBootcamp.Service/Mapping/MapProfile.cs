using AutoMapper;
using DotnetYuzuncuYilBootcamp.Core.DTOs;
using DotnetYuzuncuYilBootcamp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetYuzuncuYilBootcamp.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            //entity'den Dto'a çevirmek;
            CreateMap<Duty, DutyDto>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<EmployeeProfile, EmployeeProfileDto>().ReverseMap();

            //dto'dan entity'e çevirmek;
            CreateMap<DutyDto, Duty>();
            CreateMap<EmployeeDto, Employee>();
            CreateMap<EmployeeProfileDto, EmployeeProfile>();
        }
    }
}
