using System;
using ITA.Schedule.BLL.Interface.Base;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.BLL.Interface
{
    public interface ISubGroupBl : ICrudBl<SubGroup>
    {
        /// <summary>add a student to a subgroup</summary>
        void AddStudentToSubgroup(Guid subgroupId, Guid studentId);

        /// <summary>remove a student from a subgroup</summary>
        void RemoveStudentFromSubgroup(Guid subgroupId, Guid studentId);

        
    }
}