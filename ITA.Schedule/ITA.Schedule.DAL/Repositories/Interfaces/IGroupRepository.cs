using System;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.DAL.Repositories.Interfaces
{
    /// <summary>
    /// To be implemented by GroupRepository
    /// </summary>
    public interface IGroupRepository : ICrudRepository<Group>
    {
        // add subgroup to a group
        void AddSubgroupToGroup(Guid groupId, Guid subgroupId);
        // unlink subgroup from a group
        void UnlinkSubgroupFromGroup(Guid groupId, Guid subgroupId);
    }
}