using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITA.Schedule.Util
{
    public static class Helper
    {
        public static bool IsDateEqualWithoutTime(this DateTime curreDate, DateTime dateToCompare)
        {
            return
                curreDate.Day == dateToCompare.Day &&
                curreDate.Month == dateToCompare.Month &&
                curreDate.Year == dateToCompare.Year;
        }
    }
}
