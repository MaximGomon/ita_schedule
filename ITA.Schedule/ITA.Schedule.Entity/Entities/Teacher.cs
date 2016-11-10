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
            Subjects = new List<Subject>();
            Times = new List<TimeZoneSch>();
        }
        public virtual ICollection<Subject> Subjects { get; set; } 
        public virtual ICollection<TimeZoneSch> Times { get; set; } 
    }
}
