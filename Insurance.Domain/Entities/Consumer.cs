using Insurance.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Entities
{
    public class Consumer : IAuditEntity
    {
        public int ConsumerId { get; set; }
        public int InsuranceSetupId { get; set; }
        public string ConsumerName { get; set; }
        public int? Age { get; set; }
        public decimal BasicSalary { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModified { get; set; }
        public InsuranceSetup InsuranceSetup { get; set; }
        public ICollection<BenefitsDetail> BenefitsDetails { get; set; } = new List<BenefitsDetail>();

    }
}
