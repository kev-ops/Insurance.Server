using Insurance.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Common
{
    public class TestComparer : IEqualityComparer<BenefitsDetail>
    {
        public bool Equals(BenefitsDetail x, BenefitsDetail y)
        {
            return x.BenefitsDetailId == y.BenefitsDetailId
                   && x.ConsumerId == y.ConsumerId
                   && x.Multiple == y.Multiple
                   && x.Benefits_Amount_Quotation == y.Benefits_Amount_Quotation
                   && x.Pended_Amount == y.Pended_Amount
                   && x.Benefits == y.Benefits
                   && x.Consumer == y.Consumer;
        }

        public int GetHashCode([DisallowNull] BenefitsDetail obj)
        {
            return base.GetHashCode();
        }
    }
}
