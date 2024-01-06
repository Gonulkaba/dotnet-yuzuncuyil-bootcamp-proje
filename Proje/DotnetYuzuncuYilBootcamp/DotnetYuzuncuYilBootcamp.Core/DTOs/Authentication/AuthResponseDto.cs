using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetYuzuncuYilBootcamp.Core.DTOs.Authentication
{
    public class AuthResponseDto
    {
        public string Token { get; set; }
        public EmployeeDto Employee { get; set; }
    }
}
