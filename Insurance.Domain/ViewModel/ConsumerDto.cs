using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.ViewModel
{
    public class ConsumerDto
    {
        public int InsuranceSetupId { get; set; }
        public string ConsumerName { get; set; }
        public decimal BasicSalary { get; set; }
        public DateTime BirthDate { get; set; }
    }

}
