using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.ViewModel
{
    public class BenefitsDto
    {
        private decimal _pendedAmout = 0;
        public int ConsumerId { get; set; }
        public int Increment { get; set; }
        public int Min_Age { get; set; }
        public int Max_Age { get; set; }
        public int Age { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal GuaranteedIssue { get; set; }
        public int Multiple { get; set; }
        public bool IsWithinRange => (Age >= Min_Age && Age <= Max_Age);
        public decimal Computed => (BenefitsAmountQuotation - GuaranteedIssue);
        public decimal BenefitsAmountQuotation => (BasicSalary * Multiple);

        public decimal PendedAmount
        {
            get
            {
                //if within age range
                if (IsWithinRange)
                {
                    _pendedAmout = (BenefitsAmountQuotation > Computed && Computed > 0) ? Computed : 0;

                }

                return _pendedAmout;
            }
        }
        public decimal? Benefits => (!IsWithinRange || PendedAmount == 0) ? BenefitsAmountQuotation : null;
        public string Remarks => PendedAmount == 0 ? "Approved" : "For Approval";
    }
}
