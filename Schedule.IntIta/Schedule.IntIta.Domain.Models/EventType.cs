﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Schedule.IntIta.Domain.Models
{
    public class EventType : DeletableEntity
    {
        [DisplayName("Тип ивента")]
        public string Name { get; set; }
    }
}
