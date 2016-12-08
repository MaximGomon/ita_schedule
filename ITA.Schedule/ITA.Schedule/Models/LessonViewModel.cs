using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ITA.Schedule.Entity.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using SelectListItem = System.Web.Mvc.SelectListItem;


namespace ITA.Schedule.Models
{
    public class LessonViewModel
    {
        public Guid TeacherId { get; set; }

        public List<Teacher> TeacherList { get; set; }
        
        public Guid SubjectId { get; set; }

        public List<Subject> SubjectList { get; set; }

        public DateTime LessonDate { get; set; }

        public Guid MyGroupId { get; set; }

        public List<SelectListItem> Groups { get; set; } 

        public Guid SubGroupId { get; set; }

        public List<SubGroup> Subgroups { get; set; } 

    }
}