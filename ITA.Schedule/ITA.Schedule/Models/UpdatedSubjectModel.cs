using System;
using System.Collections.Generic;

namespace ITA.Schedule.Models
{
    /// <summary>
    /// Model of an updated subject which we receive from an html update form
    /// </summary>
    public class UpdatedSubjectModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public List<Guid> TeacherIds { get; set; }
    }
}