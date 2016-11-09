using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITA.Schedule.Entity.Entities
{
    public class TeacherSubjects : IdEntity
    {
        public virtual Teacher Teacher { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
