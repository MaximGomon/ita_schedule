using System.Collections.Generic;


namespace ITA.Schedule.Entity.Entities
{
    public class Grand : DictionaryEntity
    {
        public Grand()
        {
            SecurityGroups = new List<SecurityGroup>();
        }

        public virtual ICollection<SecurityGroup> SecurityGroups { get; set; } 
    }
}
