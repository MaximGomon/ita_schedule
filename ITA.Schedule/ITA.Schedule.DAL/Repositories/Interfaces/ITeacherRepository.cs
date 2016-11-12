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
        void AddSubjectToTeacher(Guid teacherId, Guid subjecId);
        void DeleteSubjectFromTeacher(Guid teacherId, Guid subjecId);

        IQueryable<Teacher> GetFreeTeacherOnDate(DateTime date);

        void SetTeacherBusy(Guid teacherId);

        void SetTeacherFree(Guid teacherId);

        void SetTeacherActive(Guid teacherId);

        void SetTeacherInactive(Guid teacherId);
    }
}