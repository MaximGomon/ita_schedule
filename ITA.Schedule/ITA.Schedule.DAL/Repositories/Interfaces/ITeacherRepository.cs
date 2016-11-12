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
        // set teacher busy on a particular day
        bool SetTeacherBusy(Guid teacherId, LessonTime lessonTime, DateTime day);
        // set teacher free on a particular day
        bool SetTeacherFree(Guid teacherId, LessonTime lessonTime, DateTime day);
        // set teacher active on a particular day
        bool SetTeacherActive(Guid teacherId, LessonTime lessonTime, DateTime day);
        // set teacher inactive on a particular day
        bool SetTeacherInactive(Guid teacherId, LessonTime lessonTime, DateTime day);
    }
}