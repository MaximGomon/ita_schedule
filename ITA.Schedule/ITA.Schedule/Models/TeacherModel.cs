using System;
using System.Collections.Generic;

namespace ITA.Schedule.Models
{
    /// <summary>
    /// Model to display in teachers table of the admin view
    /// </summary>
    public class TeacherModel
    {
        // Teacher ID
        public Guid Id { get; set; }
        // Teacher name
        public string Name { get; set; }
        // Teacher subjects
        public string Subjects { get; set; }
    }
}