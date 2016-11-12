﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ITA.Schedule.Entity.Entities
{
    public class TeacherAllTime : IdEntity
    {
        [Required]
        public bool IsBusy { get; set; }
        [Required]
        public bool IsActive { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }

        public virtual LessonTime LessonTime { get; set; }
        public virtual Teacher Teacher { get; set; }
       
    }
}
