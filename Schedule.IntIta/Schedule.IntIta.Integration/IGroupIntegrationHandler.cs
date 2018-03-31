using System.Collections.Generic;
using Schedule.IntIta.Domain.Models;

namespace Schedule.IntIta.Integration
{
    public interface IGroupIntegrationHandler
    {
        List<Group> GetGroupList();
        Group GetGroupById(int? groupId);
    }
}