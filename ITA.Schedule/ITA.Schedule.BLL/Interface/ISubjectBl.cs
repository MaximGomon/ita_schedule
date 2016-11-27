using System;
using System.Collections.Generic;
using ITA.Schedule.BLL.Interface.Base;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.BLL.Interface
{
    interface ISubjectBl : ICrudBl<Subject>
    {
        // update subject method
        bool UpdateSubject(Guid subjectId, string newSubjectName, int code);
    }
}
