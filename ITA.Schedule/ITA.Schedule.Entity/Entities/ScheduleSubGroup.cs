using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITA.Schedule.Entity.Entities
{
    public class ScheduleSubGroup : IdEntity
    {
        public virtual ScheduleLesson Schedule { get; set; }

        public virtual SubGroup SubGroup { get; set; }
    }
}
