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
        // ToDo uncomment and test code here with Save or Update methods
        public void AddSubjectToTeacher(Guid teacherId, Guid subjecId)
        {
//            var teacher = GetById(teacherId);
//            teacher.Subjects.Add(ContextDb.Subjects.FirstOrDefault(x => x.Id == subjecId));
//            Update(teacher);
        }

        // ToDo uncomment and test code here with Save or Update methods
        public void DeleteSubjectFromTeacher(Guid teacherId, Guid subjecId)
        {
//            var teacher = GetById(teacherId);
//            teacher.Subjects.Remove(ContextDb.Subjects.FirstOrDefault(x => x.Id == subjecId));
//            Update(teacher);
        }

        // todo come back to this method once db entities relations have been fixed
        public IQueryable<Teacher> GetFreeTeacherOnDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        // todo consult how this method should work
        public void SetTeacherBusy(Guid teacherId)
        {
            throw new NotImplementedException();
        }

        // todo consult how this method should work
        public void SetTeacherFree(Guid teacherId)
        {
            throw new NotImplementedException();
        }

        // todo consult how this method should work
        public void SetTeacherActive(Guid teacherId)
        {
            throw new NotImplementedException();
        }

        // todo consult how this method should work
        public void SetTeacherInactive(Guid teacherId)
        {
            throw new NotImplementedException();
        }
    }
}