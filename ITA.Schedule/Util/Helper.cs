using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public static class Helper
    {
        public static bool IsDateEqualWithoutTime(DateTime dayMonthYear1, DateTime dayMonthYear2)
        {
            return
                dayMonthYear1.Day == dayMonthYear2.Day &&
                dayMonthYear1.Month == dayMonthYear2.Month &&
                dayMonthYear1.Year == dayMonthYear2.Year;
        }
    }
}
