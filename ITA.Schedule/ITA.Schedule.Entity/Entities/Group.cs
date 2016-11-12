using System.Collections.Generic;

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
