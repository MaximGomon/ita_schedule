using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITA.Schedule.Entity.Entities
{
    public class ScheduleLesson : IdEntity
    {

        public ScheduleLesson()
        {
            SubGroups = new List<SubGroup>();
        }

        [Required]
        public DateTime LessonDate { get; set; }

        [Required]
        public virtual Subject Subject { get; set; }

        [Required]
        public virtual Room Room { get; set; }

        public virtual Teacher Teacher { get; set; }
        //public virtual TeacherTime TeacherTime { get; set; }
        
        public LessonTime LessonTime { get; set; }

        public virtual ICollection<SubGroup> SubGroups { get; set; }
    }
}
