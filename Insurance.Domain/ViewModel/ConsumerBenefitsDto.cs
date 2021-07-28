using Insurance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.ViewModel
{
    public class ConsumerBenefitsDto
    {
        public int ConsumerId { get; set; }
        public int InsuranceSetupId { get; set; }
        public string ConsumerName { get; set; }
        public decimal BasicSalary { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModified { get; set; }
        public ICollection<BenefitsDetailDto> BenefitsDetails { get; set; } 
    }
    public class BenefitsDetailDto
    {
        public int BenefitsDetailId { get; set; }
        public int ConsumerId { get; set; }
        public int Multiple { get; set; }
        public decimal Benefits_Amount_Quotation { get; set; }
        public decimal Pended_Amount { get; set; }
        public decimal? Benefits { get; set; }
    }
}
