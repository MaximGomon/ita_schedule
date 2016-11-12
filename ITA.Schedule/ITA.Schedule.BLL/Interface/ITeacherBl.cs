using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ITA.Schedule.BLL.Interface.Base;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.BLL.Interface
{
    interface ITeacherBl : ICrudBl<Teacher>
    {
       
        void AddSubjectToTeacher(Guid teacherId, Guid subjecId);
        void DeleteSubjectFromTeacher(Guid teacherId, Guid subjecId);
        IEnumerable<Teacher> GetFreeTeacherOnDate(DateTime date);
        void SetTeacherBusy(Guid teacherId);
        void SetTeacherFree(Guid teacherId);
        void SetTeacherActive(Guid teacherId);
        void SetTeacherInactive(Guid teacherId);

    }
}
