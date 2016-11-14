using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITA.Schedule.Util
{
    public static class Helper
    {
        public static bool IsDateEqualWithoutTime(this DateTime currentDate, DateTime dateToCompare)
        {
            return
                currentDate.Day == dateToCompare.Day &&
                currentDate.Month == dateToCompare.Month &&
                currentDate.Year == dateToCompare.Year;
        }
    }
}
