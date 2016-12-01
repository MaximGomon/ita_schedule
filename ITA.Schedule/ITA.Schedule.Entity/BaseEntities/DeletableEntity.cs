using System.ComponentModel.DataAnnotations;

namespace ITA.Schedule.Entity
{
    public class DeletableEntity : IdEntity
    {
        [Required]
        public bool IsDeleted { get; set; }
    }
}