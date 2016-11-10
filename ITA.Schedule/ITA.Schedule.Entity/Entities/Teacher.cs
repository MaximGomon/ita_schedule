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
            Times = new List<TimeZoneSch>();
        }
        public virtual ICollection<TimeZoneSch> Times { get; set; } 
    }
}
