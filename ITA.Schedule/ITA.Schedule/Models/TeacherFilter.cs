using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITA.Schedule.Util;

namespace ITA.Schedule.Models
{
	public class TeacherFilter
	{
        public DateTime StartDateTime { get; set; }

        /*public DateTime Date { get; set; }*/
        public Guid GroupId { get; set; }

        public Guid SubgroupId { get; set; }

        public List<SelectListItem> GroupList { get; set; }

        public List<SelectListItem> SubGroups { get; set; }

        public TimePeriod MyTimePeriod { get; set; }
    }
}