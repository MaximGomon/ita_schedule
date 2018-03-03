using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Schedule.IntIta.Domain.Models;

namespace Schedule.IntIta.ViewModels
{
    public class TimeSlotTypeViewModel : DeletableEntity
    {
        [Required, MinLength(2), MaxLength(20)]
        public string Type { get; set; }
    }
}
