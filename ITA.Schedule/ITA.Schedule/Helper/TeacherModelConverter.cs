using System.Collections.Generic;
using ITA.Schedule.Entity.Entities;
using ITA.Schedule.Models;

namespace ITA.Schedule.Helper
{
    public static class TeacherModelConverter
    {
        public static List<TeacherModel> ToTeacherModel(this List<Teacher> teachers)
        {
            var convertedTeachers = new List<TeacherModel>();
            
            foreach (var teacher in teachers)
            {
                var teacherModel = new TeacherModel()
                {
                    Id = teacher.Id,
                    Name = teacher.Name
                };

                var i = 0;
                foreach (var subject in teacher.Subjects)
                {
                    teacherModel.Subjects += subject.Name;
                    i++;
                    if (i < teacher.Subjects.Count)
                    {
                        teacherModel.Subjects += ", ";
                    }
                }

                convertedTeachers.Add(teacherModel);
            }
            return convertedTeachers;
        }
    }
}