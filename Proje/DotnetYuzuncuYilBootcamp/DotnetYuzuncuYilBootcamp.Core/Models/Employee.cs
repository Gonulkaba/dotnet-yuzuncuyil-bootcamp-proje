using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetYuzuncuYilBootcamp.Core.Models
{
    public class Employee : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Position { get; set; }

        //Bire çok ilişki
        public ICollection<Task> Task { get; set; }


    }
}
