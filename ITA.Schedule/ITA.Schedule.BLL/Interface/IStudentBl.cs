using System;
using System.Collections.Generic;
using ITA.Schedule.Entity.Entities;
using ITA.Schedule.BLL.Interface.Base;

namespace ITA.Schedule.BLL.Interface
{
    interface IStudentBl : ICrudBl<Student>
    {
        IEnumerable<Student> GetAllByGroup(Guid groupId);
        IEnumerable<Student> GetAllBySubGroup(Guid subGroupId);
        //IEnumerable<Student> GetStudentsBySubject(Guid subGroupId);
        void ReplaceToAnotherSubGroup(Guid studentId, Guid newSubGroupId);

        IEnumerable<Student> GetAllBySubGroup(string subGroupName);
        bool AddNewStudent(string name, Guid subgroupId);
    }
}
