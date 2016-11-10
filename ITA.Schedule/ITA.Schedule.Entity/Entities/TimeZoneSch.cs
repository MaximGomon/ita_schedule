using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITA.Schedule.Entity.Entities
{
    public class TimeZoneSch : DictionaryEntity
    {
        [Required]
        public double StartTimeInterval { get; set; }

        [Required]
        public double EndTimeInterval { get; set; }
    }
}
