using Insurance.Application;
using Insurance.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Infrastructure.Classes
{
    public class Helper : IHelper
    {
        private readonly IClock _clock;
        public Helper(IClock clock)
        {
            _clock = clock;
        }

        public int GetAge(DateTime date)
        {
            int age;
            age = DateTime.Now.Year - date.Year;
            if (_clock.GetDateTimeNow().DayOfYear < date.DayOfYear)
                age = age - 1;

            return age;
        }
    }
}
