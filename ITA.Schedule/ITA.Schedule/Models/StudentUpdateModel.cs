using System;
using System.Collections.Generic;

namespace ITA.Schedule.Models
{
    public class StudentUpdateModel
    {
        public Guid StudentId { get; set; }
        public Guid? StudentGroupId { get; set; }
        public Guid? StudentSubgroupId { get; set; }
        public ShowStudentModel Student { get; set; }
        public List<AddStudentModel> Groups { get; set; }
    }
}