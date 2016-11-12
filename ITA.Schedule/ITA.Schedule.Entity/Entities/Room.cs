using System.ComponentModel.DataAnnotations;

namespace ITA.Schedule.Entity.Entities
{
    public class Room : NamedEntity
    {
        [MinLength(1, ErrorMessage = "Too short name. Must be 1-400 chars")]
        [MaxLength(400, ErrorMessage = "Too long name. Must be 1-400 chars")]
        [Required]
        public string Address { get; set; }
    }
}
