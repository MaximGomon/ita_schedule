using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITA.Schedule.Models
{
    public class SchedulerViewModel
    {
        public Dictionary<string, int> ColumnHeaders { get; set; }

        public string DayOfSchedule { get; set; }
        public List<DateTime> RowHeaders { get; set; }
        public List<Element> Events { get; set; }
        
    }
}