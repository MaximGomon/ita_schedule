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
                    Name = teacher.Name
                };

                teacherModel.Subjects = new List<string>();

                foreach (var subject in teacher.Subjects)
                {
                    teacherModel.Subjects.Add(subject.Name);
                }

                convertedTeachers.Add(teacherModel);
            }
            return convertedTeachers;
        }
    }
}