﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.IntIta.Domain.Models
{
    public class Teacher : IdEntity
    {
        public int Id { get; set; } //for test
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        
        public Subject[] Subjects;
        public TimeSlot[] TimeSlots;
    }
}
