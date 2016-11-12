using System.Collections.Generic;

namespace ITA.Schedule.Entity.Entities
{
    public class SecurityGroup : DictionaryEntity
    {
        public SecurityGroup()
        {
            Grands = new List<Grand>();   
        }

        public virtual ICollection<Grand> Grands { get; set; } 
    }
}
