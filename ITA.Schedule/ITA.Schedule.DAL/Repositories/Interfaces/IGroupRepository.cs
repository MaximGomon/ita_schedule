using System;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.DAL.Repositories.Interfaces
{
    /// </summary>
    /// To be implemented by GroupRepository
    /// </summary>
    public interface IGroupRepository : ICrudRepository<Group>
    {
        /// <summary>add subgroup to a group</summary>
        void AddSubgroupToGroup(Guid groupId, Guid subgroupId);
        /// <summary>unlink subgroup from a group</summary>
        void UnlinkSubgroupFromGroup(Guid groupId, Guid subgroupId);
    }
}