using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetYuzuncuYilBootcamp.Core.DTOs
{
    public class DutyDto:BaseDto
    {
        public string DutyName { get; set; }
        public string Description { get; set;}
        public string Status { get; set; }
        public int EmployeeId { get; set; } 
    }
}
