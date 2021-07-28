using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Classes
{
    public class SaveResult
    {
        public string message { get; set; }
        public int rowsAffected { get; set; }
        public bool success { get; set; }
    }
}
