using System.ComponentModel.DataAnnotations;

namespace ITA.Schedule.Entity
{
    public class DictionaryEntity : NamedEntity
    {
        [Required]
        public int Code { get; set; }
    }
}