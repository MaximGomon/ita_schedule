using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITA.Schedule.Util;

namespace ITA.Schedule.Models
{
    public class TeacherFilterViewModel
    {
        public DateTime StartDateTime { get; set; }

        public Guid GroupId { get; set; }

        public Guid SubgroupId { get; set; }

        public TimePeriod MyTimePeriod { get; set; }
    }
}