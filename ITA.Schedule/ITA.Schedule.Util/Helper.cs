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

        public static DateTime MondayOfConreteMonth(this DateTime date)
        {
            DateTime monday = new DateTime(date.Year, date.Month, 1);
            monday = monday.AddDays(-1 * (int)(monday.DayOfWeek) + 1);
            return monday;
        }

        public static DateTime LastSundayOfMonth(this DateTime date)
        {
            DateTime sunday = (date.AddMonths(1).AddDays(-date.Day));
            if (sunday.DayOfWeek == DayOfWeek.Sunday)
                return sunday;

            sunday = sunday.AddDays(7 - (int)(sunday.DayOfWeek));

            return sunday;
        }
    }
}
