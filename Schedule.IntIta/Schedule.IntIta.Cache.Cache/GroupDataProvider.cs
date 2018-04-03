using System.Collections.Generic;
using Schedule.IntIta.Domain.Models;
using Schedule.IntIta.Integration;

namespace Schedule.IntIta.Cache.Cache
{
    public class GroupDataProvider : IDataProvider<Group>
    {
        private readonly IGroupIntegrationHandler _handler;

        public GroupDataProvider(IGroupIntegrationHandler handler)
        {
            _handler = handler;
        }
        public IEnumerable<Group> GetData()
        {
            return _handler.GetGroupList();
        }
    }
}
