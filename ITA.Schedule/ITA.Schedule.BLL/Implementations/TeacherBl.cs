using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ITA.Schedule.BLL.Implementations.Base;
using ITA.Schedule.BLL.Interface;
using ITA.Schedule.DAL.Repositories.Interfaces;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.BLL.Implementations
{
    class TeacherBl : CrudBll<ITeacherRepository, Teacher>, ITeacherBl
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

        public IEnumerable<Teacher> GetFreeTeacherOnDate(DateTime date)
        {
            //throw new NotImplementedException();
            var allTeachers = Repository.GetAllEntities();
            var dayLessons = new ScheduleLesson();
            var teachers = new List<Teacher>();
            foreach (var teach in allTeachers)
            {
                //if(teach.TeacherAllTimes.FirstOrDefault() == date)
                teachers.Add(teach);
            }

            return teachers;
        }

        public void SetTeacherBusy(Guid teacherId)
        {
            throw new NotImplementedException();
        }

        public void SetTeacherFree(Guid teacherId)
        {
            throw new NotImplementedException();
        }

        public void SetTeacherActive(Guid teacherId)
        {
            throw new NotImplementedException();
        }

        public void SetTeacherInactive(Guid teacherId)
        {
            throw new NotImplementedException();
        }
    }
}
