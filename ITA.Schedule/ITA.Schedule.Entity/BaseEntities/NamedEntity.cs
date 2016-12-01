using System.ComponentModel.DataAnnotations;

namespace ITA.Schedule.Entity
{
    public class NamedEntity : DeletableEntity
    {
         [MaxLength(400)]
         public string Name { get; set; }
    }
}