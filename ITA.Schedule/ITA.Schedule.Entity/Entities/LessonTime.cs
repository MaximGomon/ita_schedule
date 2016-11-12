using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITA.Schedule.Entity.Entities
{
    public class LessonTime : DictionaryEntity
    {
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime StartLessonTime { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime EndLessonTime { get; set; }
    }
}
