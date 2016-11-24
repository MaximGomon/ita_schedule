using System;
using System.Linq;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.Models
{
    public class SubjectModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        
        public SubjectModel ConvertSubjectToModel(Subject subjectToConvert)
        {
            Name = subjectToConvert.Name;
            Id = subjectToConvert.Id;
            return this;
        }
    }
}