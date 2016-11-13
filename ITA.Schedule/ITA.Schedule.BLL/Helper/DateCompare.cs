using System;

namespace ITA.Schedule.BLL.Helper
{
    public static class DateCompare
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