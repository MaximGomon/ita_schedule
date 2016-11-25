using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITA.Schedule.Entity.Entities;
using ITA.Schedule.Util;


namespace ITA.Schedule.Models
{
    public class StudentFilterViewModel
    {

        public DateTime StartDateTime { get; set; }

        /*ublic DateTime Date { get; set; }*/
        public Guid MySubjectId { get; set; }
        
        public Guid TeacherId { get; set; }

        public List<SelectListItem> TeachersList { get; set; }

        public List<SelectListItem> SubjectsList { get; set; }

        public TimePeriod MyTimePeriod { get; set; }

    }
}