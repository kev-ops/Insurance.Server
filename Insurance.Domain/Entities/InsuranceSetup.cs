using Insurance.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Entities
{
    public class InsuranceSetup : IAuditEntity
    {
        public int InsuranceSetupId { get; set; }
        public string SetupName { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public int MinRange { get; set; }
        public int MaxRange { get; set; }
        public int Increments { get; set; }
        public decimal GuaranteedIssue { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModified { get; set; }
        public ICollection<Consumer> Consumers { get; set; }

    }
}
