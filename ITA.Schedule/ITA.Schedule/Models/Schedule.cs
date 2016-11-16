using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.Models
{
    public class Schedule
    {
        public string MySubjects { get; set; }

        public List<ScheduleLesson> MyTime { get; set; }


    }
}