using System;
using ITA.Schedule.BLL.Interface.Base;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.BLL.Interface
{
    public interface ISubGroupBl : ICrudBl<SubGroup>
    {
        // add a student to a subgroup
        void AddStudentToSubgroup(Guid subgroupId, Guid studentId);

        // remove a student from a subgroup
        void RemoveStudentFromSubgroup(Guid subgroupId, Guid studentId);

    }
}