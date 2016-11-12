using System;
using ITA.Schedule.BLL.Implementations.Base;
using ITA.Schedule.BLL.Interface;
using ITA.Schedule.DAL.Repositories.Interfaces;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.BLL.Implementations
{
    public class SubGroupBl : CrudBll<ISubgroupRepository, SubGroup>, ISubGroupBl
    {
        public SubGroupBl(ISubgroupRepository repository) : base(repository)
        {
        }

        public void AddStudentToSubgroup(Guid subgroupId, Guid studentId)
        {
            Repository.AddStudentToSubgroup(subgroupId, studentId);
        }

        public void RemoveStudentFromSubgroup(Guid subgroupId, Guid studentId)
        {
            Repository.RemoveStudentFromSubgroup(subgroupId, studentId);
        }
    }
}
