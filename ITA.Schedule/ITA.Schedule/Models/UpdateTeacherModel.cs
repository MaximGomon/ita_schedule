using System;
using System.Collections.Generic;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.Models
{
    public class UpdateTeacherModel
    {
        public Teacher Teacher { get; set; }
        /*public List<Guid> SubjectIds { get; set; }
        public List<string> Subjects { get; set; }*/
        //ToDo consult Max about it
        public List<SubjectModel> Subjects { get; set; }
    }
}