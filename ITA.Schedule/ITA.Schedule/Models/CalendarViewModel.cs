using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITA.Schedule.Models
{
    public class CalendarViewModel
    {
        public CalendarViewModel()
        {
            ColumnHeaders=new List<string>
            {
                "Понеділок",
                "Вівторок",
                "Середа",
                "Четвер",
                "П’ятниця",
                "Субота",
                "Неділя",
            };
        }

        public List<string> ColumnHeaders{get;}

        public DateTime FirstDayOfWeekInMonth { get; set; }

        public DateTime LastDayOfWeekInMonth { get; set; }


    }
}