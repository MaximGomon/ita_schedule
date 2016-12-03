using System;
using ITA.Schedule.Entity.Entities;
using ITA.Schedule.Util;

namespace ITA.Schedule.Models
{
    public class ShowStudentModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public string Subgroup { get; set; }
        public EntityStatus Status { get; set; }

        public ShowStudentModel ConvertStudentToModel(Student student)
        {
            Id = student.Id;
            Name = student.Name;
            if (student.SubGroup != null)
            {
                Group = student.SubGroup.Group.Name;
                Subgroup = student.SubGroup.Name;
            }

            Status = student.IsDeleted ? EntityStatus.Deleted : EntityStatus.Active;

            return this;
        }
    }
}