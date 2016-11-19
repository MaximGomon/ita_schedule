using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ITA.Schedule.Entity.Entities;
using ITA.Schedule.Util;

namespace ITA.Schedule.Models
{
    public class StudentFilterViewModel
    {

        public DateTime StartDateTime { get; set; }


        public DateTime Date { get; set; }
        public string MySubject { get; set; }
        
        public string Teacher { get; set; }

        public TimePeriod MyTimePeriod { get; set; }

    }
}