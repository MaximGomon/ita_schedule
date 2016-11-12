using System;
using System.Linq;
using ITA.Schedule.DAL.Repositories.Interfaces;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.DAL.Repositories.Implementations
{
    /// <summary>
    /// Repository to perform CRUD operations ofver Teacher entity
    /// </summary>
    public class TeacherRepository : CrudRepository<Teacher>, ITeacherRepository
    {
        // Method to add particular subject from a teacher
        public void AddSubjectToTeacher(Guid teacherId, Guid subjecId)
        {
            var teacher = GetById(teacherId);
            teacher.Subjects.Add(ContextDb.Subjects.FirstOrDefault(x => x.Id == subjecId));
            Update(teacher);
        }

        // Method to delete particular subject from a teacher
        public void DeleteSubjectFromTeacher(Guid teacherId, Guid subjecId)
        {
            var teacher = GetById(teacherId);
            teacher.Subjects.Remove(ContextDb.Subjects.FirstOrDefault(x => x.Id == subjecId));
            Update(teacher);
        }

        // todo come back to this method
        public IQueryable<Teacher> GetFreeTeacherOnDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        // todo consult how this method should work
        public void SetTeacherBusy(Guid teacherId, LessonTime lessonTime, DayInWeek day)
        {
            var teacher = GetById(teacherId);
            //teacher.
//            teacher.TeacherAllTimes.
        }

        // todo consult how this method should work
        public void SetTeacherFree(Guid teacherId, LessonTime lessonTime, DayInWeek day)
        {
            throw new NotImplementedException();
        }

        // todo consult how this method should work
        public void SetTeacherActive(Guid teacherId, LessonTime lessonTime, DayInWeek day)
        {
            throw new NotImplementedException();
        }

        // todo consult how this method should work
        public void SetTeacherInactive(Guid teacherId, LessonTime lessonTime, DayInWeek day)
        {
            throw new NotImplementedException();
        }
    }
}