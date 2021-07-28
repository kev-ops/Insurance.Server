using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Classes
{
    public class GetResult<T> where T : class
    {
        public List<T> data { get; set; }
        public int total { get; set; }
        public bool success { get; set; }
    }
}
