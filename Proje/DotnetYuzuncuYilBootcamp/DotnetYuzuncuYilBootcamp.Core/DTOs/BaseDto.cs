using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetYuzuncuYilBootcamp.Core.DTOs
{
    public abstract class BaseDto
    {
        public int Id { get; set; }
        public DateTime StartedDate { get; set; }
    }
}
