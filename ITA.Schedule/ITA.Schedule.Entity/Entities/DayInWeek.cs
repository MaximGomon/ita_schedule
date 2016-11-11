using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITA.Schedule.Entity.Entities
{
    public class DayInWeek : DictionaryEntity
    {
        public DayInWeek()
        {
            Times = new List<LessonTime>();
        }

        public virtual ICollection<LessonTime> Times { get; set; } 
    }
}
