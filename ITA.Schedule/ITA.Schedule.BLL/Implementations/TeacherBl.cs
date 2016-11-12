using System;
using System.Collections.Generic;
using System.Linq;
using ITA.Schedule.BLL.Implementations.Base;
using ITA.Schedule.BLL.Interface;
using ITA.Schedule.DAL.Repositories.Interfaces;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.BLL.Implementations
{
    public class TeacherBl : CrudBll<ITeacherRepository, Teacher>, ITeacherBl
    {
       
        public TeacherBl(ITeacherRepository repository) : base(repository)
        {

        }

        public void AddSubjectToTeacher(Guid teacherId, Guid subjecId)
        {
            Repository.AddSubjectToTeacher(teacherId, subjecId);
        }

        public void DeleteSubjectFromTeacher(Guid teacherId, Guid subjecId)
        {
            Repository.DeleteSubjectFromTeacher(teacherId, subjecId);
        }

        public bool SetTeacherBusy(Guid teacherId, LessonTime lessonTime, DateTime day)
        {
            return Repository.SetTeacherBusy(teacherId, lessonTime, day);
        }

        public bool SetTeacherFree(Guid teacherId, LessonTime lessonTime, DateTime day)
        {
            return Repository.SetTeacherFree(teacherId, lessonTime, day);
        }

        public bool SetTeacherActive(Guid teacherId, LessonTime lessonTime, DateTime day)
        {
            return Repository.SetTeacherActive(teacherId, lessonTime, day);
        }

        public bool SetTeacherInactive(Guid teacherId, LessonTime lessonTime, DateTime day)
        {
            return Repository.SetTeacherInactive(teacherId, lessonTime, day);
        }

        public IEnumerable<Teacher> GetFreeTeacherOnDate(DateTime date)
        {
            var allTeachers = Repository.GetAllEntities();
            var teachersFree = new List<Teacher>();

            foreach (var teacher in allTeachers)
            {
                if (teacher.TeacherAllTimes.Any(t => t.IsActive == true && t.IsBusy == false &&
                    t.Date.Day == date.Day && t.Date.Month == date.Month && t.Date.Year == date.Year))
                {
                    teachersFree.Add(teacher);
                }
                    
            }

            return teachersFree;
        }

       
    }
}
