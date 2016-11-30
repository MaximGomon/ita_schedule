using System;
using System.Collections.Generic;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.Models
{
    /// <summary>
    /// Model to be passed to the teachers list view
    /// </summary>
    public class TeacherAddUpdateModel
    {
        public Teacher Teacher { get; set; }
        public List<SubjectModel> Subjects { get; set; }
    }
}