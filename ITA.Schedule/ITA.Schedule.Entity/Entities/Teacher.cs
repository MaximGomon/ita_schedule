using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITA.Schedule.Entity.Entities
{
    public class Teacher : NamedEntity
    {
        public Teacher()
        {
            LessonTimes = new List<LessonTime>();
            Subjects = new List<Subject>();
        }
        public virtual ICollection<LessonTime> LessonTimes { get; set; } 
        public virtual ICollection<Subject> Subjects { get; set; } 
    }
}
