using System;
using System.Collections.Generic;
using ITA.Schedule.BLL.Interface.Base;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.BLL.Interface
{
    interface IGroupBl : ICrudBl<Group>
    {
        /// <summary>add subgroup to a group</summary>
        void AddSubgroupToGroup(Guid groupId, Guid subgroupId);
        /// <summary>unlink subgroup from a group</summary>
        void UnlinkSubgroupFromGroup(Guid groupId, Guid subgroupId);
        IEnumerable<SubGroup> GetAllSubGroups(Guid groupId);
        
    }
}
