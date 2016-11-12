using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITA.Schedule.Entity.Entities
{
    public class SubGroup : NamedEntity
    {
        public SubGroup()
        {
            Students = new List<Student>();
            ScheduleLessons = new List<ScheduleLesson>();
        }

        public virtual Group Group { get; set; }

        public virtual ICollection<Student> Students { get; set; } 
        public virtual ICollection<ScheduleLesson> ScheduleLessons { get; set; } 
    }
}
