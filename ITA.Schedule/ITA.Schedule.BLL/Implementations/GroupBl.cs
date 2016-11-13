using System;
using System.Collections.Generic;
using ITA.Schedule.BLL.Implementations.Base;
using ITA.Schedule.BLL.Interface;
using ITA.Schedule.DAL.Repositories.Interfaces;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.BLL.Implementations
{
    public class GroupBl : CrudBll<IGroupRepository, Group>, IGroupBl
    {
        private readonly ISubgroupRepository _subgroupRepository;
        public GroupBl(IGroupRepository repository, ISubgroupRepository subgroupRepository) : base(repository)
        {
            _subgroupRepository = subgroupRepository;
        }

        public void AddSubgroupToGroup(Guid groupId, Guid subgroupId)
        {
            Repository.AddSubgroupToGroup(groupId, subgroupId);
        }

        public void UnlinkSubgroupFromGroup(Guid groupId, Guid subgroupId)
        {
            Repository.UnlinkSubgroupFromGroup(groupId, subgroupId);
        }

        public IEnumerable<SubGroup> GetAllSubGroups(Guid groupId)
        {
            return _subgroupRepository.Get(sg => sg.Group.Id == groupId);
        }

        
    }
}
