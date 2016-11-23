using System;
using System.Collections.Generic;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.Models
{
    public class UpdatedTeacherModel
    {
        public Teacher Teacher { get; set; }
        public List<Guid> SubjectIds { get; set; }
    }
}