using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Common
{
    public interface IAuditEntity
    {
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
