using System;
using System.Collections.Generic;
using ITA.Schedule.BLL.Interface.Base;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.BLL.Interface
{
    interface ISubjectBl : ICrudBl<Subject>
    {
        /// <summary> update subject method</summary>
        bool UpdateSubject(Guid subjectId, string newSubjectName, int code);
    }
}
