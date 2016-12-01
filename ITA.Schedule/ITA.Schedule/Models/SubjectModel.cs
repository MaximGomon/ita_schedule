using System;
using System.Linq;
using ITA.Schedule.Entity.Entities;
using ITA.Schedule.Util;

namespace ITA.Schedule.Models
{
    public class SubjectModel
    {
        // subject Id
        public Guid Id { get; set; }
        // subject name
        public string Name { get; set; }
        // subject code
        public int Code { get; set; }
        // Teachers who lead the subject
        public string Teachers { get; set; }
        // subject status
        public EntityStatus Status { get; set; }

        // convers tubject to a subject model for a view
        public SubjectModel ConvertSubjectToModel(Subject subjectToConvert)
        {
            Name = subjectToConvert.Name;
            Id = subjectToConvert.Id;
            Code = subjectToConvert.Code;

            var i = 0;
            foreach (var teacher in subjectToConvert.Teachers)
            {
                Teachers += teacher.Name;
                i++;
                if (i < subjectToConvert.Teachers.Count)
                {
                    Teachers += ", ";
                }
            }

            Status = subjectToConvert.IsDeleted ? EntityStatus.Deleted : EntityStatus.Active;

            return this;
        }
    }
}