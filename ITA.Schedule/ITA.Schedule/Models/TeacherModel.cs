using System;
using System.Collections.Generic;
using ITA.Schedule.Entity.Entities;
using ITA.Schedule.Util;

namespace ITA.Schedule.Models
{
    /// <summary>
    /// Model to display in teachers table of the admin view
    /// </summary>
    public class TeacherModel
    {
        // Teacher ID
        public Guid Id { get; set; }
        // Teacher name
        public string Name { get; set; }
        // Teacher subjects
        public string Subjects { get; set; }
        // teacher status
        public EntityStatus Status { get; set; }

        // convers tubject to a subject model for a view
        public TeacherModel ConvertTeacherToModel(Teacher teacherToConvert)
        {
            Name = teacherToConvert.Name;
            Id = teacherToConvert.Id;

            var i = 0;
            foreach (var subject in teacherToConvert.Subjects)
            {
                Subjects += subject.Name;
                i++;
                if (i < teacherToConvert.Subjects.Count)
                {
                    Subjects += ", ";
                }
            }

            Status = teacherToConvert.IsDeleted ? EntityStatus.Deleted : EntityStatus.Active;

            return this;
        }
    }
}