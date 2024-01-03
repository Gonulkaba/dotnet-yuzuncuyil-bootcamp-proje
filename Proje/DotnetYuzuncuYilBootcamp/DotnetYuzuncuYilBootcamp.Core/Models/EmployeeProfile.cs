using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotnetYuzuncuYilBootcamp.Core.Models
{
    public class EmployeeProfile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        //Foreign key
        public int EmployeeId { get; set; }

        //Birebir ilişki
        public Employee Employee { get; set; }

    }
}
