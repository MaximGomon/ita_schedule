using System.Collections.Generic;

namespace ITA.Schedule.Entity.Entities
{
    public class Subject : DictionaryEntity
    {
        public Subject()
        {
            Teachers = new List<Teacher>();
        }

        public virtual ICollection<Teacher> Teachers { get; set; } 
    }
}
