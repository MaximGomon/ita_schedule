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

        public virtual IQueryable<TimeZoneSch> Time { get; set; }
        public virtual IQueryable<Teacher> Teacher { get; set; }
        public virtual IQueryable<DayInWeek> Day { get; set; }
    }
}
