using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITA.Schedule.Entity.Entities
{
    public class TeacherTime : IdEntity
    {
        [Required]
        public bool IsBusy { get; set; }
        [Required]
        public bool IsActive { get; set; }

        public virtual LessonTime LessonTime { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual DayInWeek Day { get; set; }
    }
}
