using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ITA.Schedule.Entity.Entities;
using ITA.Schedule.Util;

namespace ITA.Schedule.Models
{
    public class StudentFilter
    {

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDateTime { get; set; } = DateTime.Now;

        public List<string> MySubjects { get; set; }
        
        public List<string> Teachers { get; set; }

        public TimePeriod MyTimePeriod { get; set; }

    }
}