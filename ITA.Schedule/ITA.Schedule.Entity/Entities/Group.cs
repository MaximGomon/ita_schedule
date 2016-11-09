using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITA.Schedule.Entity.Entities
{
    public class Group : NamedEntity
    {
        public Group()
        {
            SubGroups = new List<SubGroup>();
        }

        public virtual ICollection<SubGroup> SubGroups { get; set; }
    }
}
