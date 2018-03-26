using System;
using System.Collections.Generic;
using System.Linq;
using Schedule.Intita.ApiRequest;
using Schedule.IntIta.Domain.Models;
using Schedule.IntIta.Integration.IntegrationModels;
namespace Schedule.IntIta.Integration
{
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
        public Group GetGroupById(int groupId)
        {
            var apiRequest = new ApiRequest<GroupIntegrationModel>();
            var response = apiRequest.Url("http://sso.intita.com/api/offline/group/" + groupId + "/")
                .Authenticate()
                .Get()
                .Send();

            Group group = new Group()
            {
                Id = response.Response.Id,
                Name = response.Response.Name

            };
            return group;
        }

        private List<SubGroup> GetSubGroupsByGroupId(int groupId)
        {
            var apiRequest = new ApiRequest<List<SubGroupIntegrationModel>>();
            var response = apiRequest.Url("http://sso.intita.com/api/offline/group/" + groupId + "/subgroups")
                .Authenticate()
                .Get()
                .Send();
            return ConvertToSubGroup(response.Response, groupId);
        }

        private List<Group> ConvertToGroup(List<GroupIntegrationModel> modelList)
        {
            try
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
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private List<SubGroup> ConvertToSubGroup(List<SubGroupIntegrationModel> modelList, int groupId)
        {
            try
            {
                List<SubGroup> subgroups = new List<SubGroup>();
                if (modelList == null || !modelList.Any())
                    return subgroups;

                foreach (var item in modelList)
                {
                    try
                    {
                        subgroups.Add(new SubGroup()
                        {
                            Id = item.Id,
                            Name = item.Name,
                            GroupId = groupId
                        });
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }

                }

                return subgroups;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
