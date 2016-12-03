using System;
using System.Collections.Generic;

namespace ITA.Schedule.Models
{
    public class AddStudentModel
    {
        public string GroupName { get; set; }
        public Guid GroupId { get; set; }
        public Dictionary<string, string> Subgroups { get; set; }
    }
}