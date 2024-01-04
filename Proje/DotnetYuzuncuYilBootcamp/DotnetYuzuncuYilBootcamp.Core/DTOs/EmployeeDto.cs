using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetYuzuncuYilBootcamp.Core.DTOs
{
    public class EmployeeDto: BaseDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
    }
}
