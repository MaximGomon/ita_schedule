using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITA.Schedule.Models
{
    public class StudentViewModel
    {
        public StudentFilterViewModel Filter { get; set; }

        public SchedulerViewModel Scheduler { get; set; }

        public List<SchedulerViewModel> ScheduleForWeek { get; set; }

        public CalendarViewModel Calendar { get; set; }
    }
}