using System.ComponentModel.DataAnnotations;

namespace ITA.Schedule.Entity
{
    public class NamedEntity : IdEntity
    {
         [MaxLength(400)]
         public string Name { get; set; }
    }
}