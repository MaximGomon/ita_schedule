
namespace Schedule.IntIta.Domain.Models
{
     public class Group : IdEntity
    {
        public string Name { get; set; }
        public int NumberOfStudents { get; set; }
        public SubGroup[] Subgroups { get; set; }
    }
}
