using System.ComponentModel.DataAnnotations;

namespace Schedule.IntIta.Domain.Models
{
    /// <summary>Represents the type of time slot.</summary>
    public class TimeSlotTypes
    {
        /// <summary>Unique identificator of type. This field must have [Key] attribute.</summary>
        [Key]
        public int Id { get; set; }

        /// <summary>Represents the name of type. This field must be [Required].</summary>
        [Required, MinLength(2), MaxLength(20)]
        public string Type { get; set; }
    }
}