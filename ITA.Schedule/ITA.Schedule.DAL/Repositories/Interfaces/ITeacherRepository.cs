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
        /// <summary>adding a subject to a teacher</summary>
        void AddSubjectToTeacher(Guid teacherId, Guid subjecId);
        /// <summary>delete subject from a teacher</summary>
        void DeleteSubjectFromTeacher(Guid teacherId, Guid subjecId);
        /// <summary>set teacher busy on a particular day</summary>
        bool SetTeacherBusy(Guid teacherId, LessonTime lessonTime, DateTime day);
        /// <summary>set teacher free on a particular day</summary>
        bool SetTeacherFree(Guid teacherId, LessonTime lessonTime, DateTime day);
        /// <summary>set teacher active on a particular day</summary>
        bool SetTeacherActive(Guid teacherId, LessonTime lessonTime, DateTime day);
        /// <summary>set teacher inactive on a particular day</summary>
        bool SetTeacherInactive(Guid teacherId, LessonTime lessonTime, DateTime day);
    }
}