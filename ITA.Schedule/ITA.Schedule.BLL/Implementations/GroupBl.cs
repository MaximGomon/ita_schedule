using System;
using System.Collections.Generic;
using System.Threading;
using ITA.Schedule.BLL.Implementations.Base;
using ITA.Schedule.BLL.Interface;
using ITA.Schedule.DAL.Repositories.Interfaces;
using ITA.Schedule.Entity.Entities;
using NLog;
using NLog.Fluent;

namespace ITA.Schedule.BLL.Implementations
{
    public class GroupBl : CrudBll<IGroupRepository, Group>, IGroupBl
    {
        private readonly ISubgroupRepository _subgroupRepository;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        

        public GroupBl(IGroupRepository repository, ISubgroupRepository subgroupRepository) : base(repository)
        {
            _subgroupRepository = subgroupRepository;                     
        }

        public void AddSubgroupToGroup(Guid groupId, Guid subgroupId)
        {
            Repository.AddSubgroupToGroup(groupId, subgroupId);
            _logger.Info("AddSubgroupToGroup ({0} , {1})", groupId, subgroupId);
        }

        public void UnlinkSubgroupFromGroup(Guid groupId, Guid subgroupId)
        {
            Repository.UnlinkSubgroupFromGroup(groupId, subgroupId);
            _logger.Info("UnlinkSubgroupFromGroup ({0} , {1})", groupId, subgroupId);
        }

        public IEnumerable<SubGroup> GetAllSubGroups(Guid groupId)
        {
            _logger.Info("GetAllSubGroups ({0})", groupId);
            return _subgroupRepository.Get(sg => sg.Group.Id == groupId);
        }
        
    }
}
