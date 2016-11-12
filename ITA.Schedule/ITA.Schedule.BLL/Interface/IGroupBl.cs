using System;
using ITA.Schedule.BLL.Interface.Base;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.BLL.Interface
{
    interface IGroupBl : ICrudBl<Group>
    {
        // add subgroup to a group
        void AddSubgroupToGroup(Guid groupId, Guid subgroupId);
        // unlink subgroup from a group
        void UnlinkSubgroupFromGroup(Guid groupId, Guid subgroupId);

    }
}
