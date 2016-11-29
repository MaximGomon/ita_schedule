using System;
using System.Collections.Generic;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.Models
{
    /// <summary>
    /// Model of an updated teacher which we receive from an html update form
    /// </summary>
    public class TeacherUpdatedModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Guid> SubjectIds { get; set; }
    }
}