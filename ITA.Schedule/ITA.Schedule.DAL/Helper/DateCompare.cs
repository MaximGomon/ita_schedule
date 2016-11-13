using System;

namespace ITA.Schedule.DAL.Helper
{
    //todo  - how delete this double helper class and use the same from ITA.Schedule.BLL.Helper
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