using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Schedule.IntIta.ViewModels
{
    public class TimeSlotViewModel
    {
        [Required, MinLength(2), MaxLength(20)]
        public DateTime StartTime { get; set; }
        [Required, MinLength(2), MaxLength(20)]
        public DateTime EndTime { get; set; }
        public int IdType { get; set; }


    }
}
