using System;

namespace ITA.Schedule.Models
{
    public class StudentModel
    {
        public Guid StudentId { get; set; }
        public string Name { get; set; }
        public Guid SubgroupId { get; set; }
    }
}