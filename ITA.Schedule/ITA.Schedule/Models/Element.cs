using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITA.Schedule.Models
{
    public class Element
    {
        //Lesson name
        public string Name { get; set; }

        //adress
        public string Description { get; set; }

        public int LessonNumber { get; set; }
        
        public DateTime LessonDate { get; set; }

        public Guid ElementId { get; set; }
    }
}