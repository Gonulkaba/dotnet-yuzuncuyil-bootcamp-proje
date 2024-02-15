using DotnetYuzuncuYilBootcamp.Core.DTOs;
using DotnetYuzuncuYilBootcamp.Core.DTOs.Authentication;
using DotnetYuzuncuYilBootcamp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetYuzuncuYilBootcamp.Core.Services
{
    public interface IEmployeeService : IService<Employee>
    {
        string GeneratePasswordHash(string userName, string password);
        EmployeeDto FindUser(string userName, string password);
        Employee UpdateEmployee(Employee employee, AuthRequestDto authRequestDto);
        AuthResponseDto Login(AuthLoginDto request);
        Employee SignUp(AuthRequestDto authDto);
    }
}
