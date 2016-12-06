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

        public List<SelectListItem> TeacherList { get; set; }
        
        public Guid SubjectId { get; set; }

        public List<SelectListItem> SubjectList { get; set; }

        public DateTime LessonDate { get; set; }

        public Guid GroupId { get; set; }

        public Guid SubGroupId { get; set; }

    }
}