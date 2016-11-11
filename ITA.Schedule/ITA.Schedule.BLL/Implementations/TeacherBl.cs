using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ITA.Schedule.BLL.Implementations.Base;
using ITA.Schedule.BLL.Interface;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.BLL.Implementations
{
    class TeacherBl : /*CrudBll<ITeacherRepositroy, Teacher>,*/ ITeacherBl
    {
        public IQueryable<Teacher> Get(Expression<Func<Teacher, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Teacher> GetAll()
        {
            throw new NotImplementedException();
        }

        public Teacher GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Teacher entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Teacher entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(Teacher entity)
        {
            throw new NotImplementedException();
        }

        public void InsertRange(IEnumerable<Teacher> entity)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
        
        public void AddSubjectToTeacher(Guid teacherId, Guid subjecId)
        {
            throw new NotImplementedException();
        }

        public void DeleteSubjectFromTeacher(Guid teacherId, Guid subjecId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Teacher> GetFreeTeacherOnDate(DateTime date)
        {
            throw new NotImplementedException();
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
