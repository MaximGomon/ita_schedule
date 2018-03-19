
using System.Collections.Generic;

namespace Schedule.IntIta.Domain.Models
{
     public class Group : DictionaryEntity
    {
        public string Name { get; set; }
        public int NumberOfStudents { get; set; }
        public List<SubGroup> Subgroups { get; set; }
    }
}
