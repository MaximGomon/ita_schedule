﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Schedule.IntIta.ViewModels
{
    public class TimeSlotTypeViewModel
    {
        [Required, MinLength(2), MaxLength(20)]
        public string Type { get; set; }
    }
}
