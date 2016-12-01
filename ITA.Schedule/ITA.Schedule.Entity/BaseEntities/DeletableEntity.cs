using System.ComponentModel.DataAnnotations;

namespace ITA.Schedule.Entity
{
    public class DeletableEntity
    {
        [Required]
        public bool IsDeleted { get; set; }
    }
}