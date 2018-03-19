using System.Collections.Generic;
using Schedule.Intita.ApiRequest;
using Schedule.IntIta.Domain.Models;
using Schedule.IntIta.Integration.IntegrationModels;
namespace Schedule.IntIta.Integration
{
    public interface IGroupIntegrationHandler
    {
        List<Group> GetGroupList();
    }

    public class GroupIntegrationHandler : IGroupIntegrationHandler
    {
        public List<Group> GetGroupList()
        {
            var apiRequest = new ApiRequest<List<GroupIntegrationModel>>();
            var response = apiRequest.Url("http://sso.intita.com/api/offline/groups")
                .Authenticate()
                .Get()
                .Send();
            var groups = ConvertToGroup(response.Response);
            foreach (var item in groups)
            {
                item.Subgroups = GetSubGroupsByGroupId(item.Id);
            }
            return groups;
        }

        private List<SubGroup> GetSubGroupsByGroupId(int groupId)
        {
            var apiRequest = new ApiRequest<List<SubGroupIntegrationModel>>();
            var response = apiRequest.Url("http://sso.intita.com/api/offline/group" + groupId + "/subgroups")
                .Authenticate()
                .Get()
                .Send();
            return ConvertToSubGroup(response.Response, groupId);
        }

        private List<Group> ConvertToGroup(List<GroupIntegrationModel> modelList)
        {
            List<Group> groups = new List<Group>();
            foreach (var item in modelList)
            {
                groups.Add(new Group()
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }
            return groups;
        }

        private List<SubGroup> ConvertToSubGroup(List<SubGroupIntegrationModel> modelList, int groupId)
        {
            List<SubGroup> subgroups = new List<SubGroup>();
            foreach (var item in modelList)
            {
                subgroups.Add(new SubGroup()
                {
                    Id = item.Id,
                    Name = item.Name,
                    GroupId = groupId
                });
            }
            return subgroups;
        }
    }
}
