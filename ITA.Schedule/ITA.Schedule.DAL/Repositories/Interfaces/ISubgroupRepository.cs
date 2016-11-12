using System;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.DAL.Repositories.Interfaces
{
    /// <summary>
    /// To be implemented by SubgroupRepo
    /// </summary>
    public interface ISubgroupRepository : ICrudRepository<SubGroup>
    {
        // add a student to a subgroup
        void AddStudentToSubgroup(Guid subgroupId, Guid studentId);

        // remove a student from a subgroup
        void RemoveStudentFromSubgroup(Guid subgroupId, Guid studentId);
    }
}