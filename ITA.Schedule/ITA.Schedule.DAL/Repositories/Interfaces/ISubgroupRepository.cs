using System;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.DAL.Repositories.Interfaces
{
    /// <summary>
    /// To be implemented by SubgroupRepo
    /// </summary>
    public interface ISubgroupRepository : ICrudRepository<SubGroup>
    {
        /// <summary>add a student to a subgroup</summary>
        void AddStudentToSubgroup(Guid subgroupId, Guid studentId);

        /// <summary>remove a student from a subgroup</summary>
        void RemoveStudentFromSubgroup(Guid subgroupId, Guid studentId);
    }
}