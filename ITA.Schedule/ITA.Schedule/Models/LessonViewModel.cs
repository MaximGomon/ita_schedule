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

        public List<SelectListItem> TeacherList { get; set; } = new List<SelectListItem>();

        public Guid SubjectId { get; set; }

        public List<SelectListItem> SubjectList { get; set; } = new List<SelectListItem>();

        public DateTime LessonDate { get; set; }

        public Guid LessonTimeId { get; set; }

        public  List<SelectListItem> LessonsTimeList { get; set; } = new List<SelectListItem>();

        public Guid MyGroupId { get; set; }

        public List<SelectListItem> GroupsList { get; set; } = new List<SelectListItem>(); 

        public Guid SubGroupId { get; set; }

        public List<SelectListItem> SubgroupsList { get; set; } = new List<SelectListItem>();

        public Guid RoomId { get; set; }

        public  List<SelectListItem> RoomsList { get; set; } = new List<SelectListItem>();

    }
}