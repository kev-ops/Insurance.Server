using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Entities
{
    public class BenefitsDetail
    {
        public int BenefitsDetailId { get; set; }
        public int ConsumerId { get; set; }
        public int Multiple { get; set; }
        public decimal Benefits_Amount_Quotation { get; set; }
        public decimal Pended_Amount { get; set; }
        public decimal? Benefits { get; set; }
        public Consumer Consumer { get; set; }



    }
}
