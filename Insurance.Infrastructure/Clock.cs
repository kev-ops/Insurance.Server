using Insurance.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Infrastructure
{
    public class Clock : IClock
    {
        public DateTime GetDateTimeNow()
        {
            return DateTime.UtcNow;
        }
    }
}
