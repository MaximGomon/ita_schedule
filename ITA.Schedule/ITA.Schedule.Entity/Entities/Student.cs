﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITA.Schedule.Entity.Entities
{
    public class Student : NamedEntity
    {
        public virtual SubGroup SubGroup { get; set; }
    }
}
