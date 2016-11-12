﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITA.Schedule.Entity.Entities
{
    public class Teacher : NamedEntity
    {
        public Teacher()
        {
            TeacherAllTimes = new List<TeacherAllTime>();
            Subjects = new List<Subject>();
        }
        public virtual ICollection<TeacherAllTime> TeacherAllTimes { get; set; } 
        public virtual ICollection<Subject> Subjects { get; set; } 
    }
}
