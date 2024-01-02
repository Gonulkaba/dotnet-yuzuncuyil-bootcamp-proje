using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetYuzuncuYilBootcamp.Core.Models
{
    public class Task : BaseEntity
    {
        public string TaskName { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        //Foreign key
        public int EmployeeId { get; set; }

        //Bire çok ilişki
        public Employee Employee { get; set; }

    }
}
