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
        [Required]
        public DateTime LessonDate { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual TeacherTime TeacherTime { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Room Room { get; set; }
        public virtual ICollection<SubGroup> SubGroups { get; set; }
    }
}
