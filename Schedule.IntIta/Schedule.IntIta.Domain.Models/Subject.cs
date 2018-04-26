using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Schedule.IntIta.Domain.Models
{
    public class Subject : DictionaryEntity
    {
        public string Name { get; set; }
        [Required]
        public string Color { get; set; }
    }
}
