using System;
using System.Linq;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.DAL.Repositories.Interfaces
{
    /// <summary>
    /// Interface to be implemented by TeacherRepository
    /// </summary>
    public interface ITeacherRepository : ICrudRepository<Teacher>
    {
        // adding a subject to a teacher
        void AddSubjectToTeacher(Guid teacherId, Guid subjecId);
        // delete subject from a teacher
        void DeleteSubjectFromTeacher(Guid teacherId, Guid subjecId);

        IQueryable<Teacher> GetFreeTeacherOnDate(DateTime date);

        void SetTeacherBusy(Guid teacherId, LessonTime lessonTime, DayInWeek day);

        void SetTeacherFree(Guid teacherId, LessonTime lessonTime, DayInWeek day);

        void SetTeacherActive(Guid teacherId, LessonTime lessonTime, DayInWeek day);

        void SetTeacherInactive(Guid teacherId, LessonTime lessonTime, DayInWeek day);
    }
}