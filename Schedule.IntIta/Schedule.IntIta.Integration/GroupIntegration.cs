using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Http;
using Schedule.Intita.ApiRequest;
using Schedule.IntIta.Domain.Models;
using Newtonsoft.Json;
using Schedule.Intita.ApiRequest.Enumerations;
using Schedule.IntIta.Integration.IntegrationModels;
namespace Schedule.IntIta.Integration
{
    public class GroupIntegration
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }

        public static List<Group> GetGroupList()
        {
            List<Group> groups = new List<Group>();
           // List<SubGroup> subgroups = new List<SubGroup>();
            ApiRequest<List<GroupIntegrationModel>> apiRequest = new ApiRequest<List<GroupIntegrationModel>>();
            var response = apiRequest.Url("http://sso.intita.com/api/offline/groups")
                .Authenticate()
                .Get()
                .Send();
            groups = ConvertToGroup(response.Response);
            //subgroups = GetSubGroupList(groups);
            //foreach (var item in groups)
            //{
            //    foreach (var sItem in subgroups)
            //    {
            //        if (item.Id == sItem.GroupId)
            //        {
            //            item.Subgroups = subgroups;
            //        }

            //    }

            //}
            return groups;
        }
        private static List<Group> ConvertToGroup(List<GroupIntegrationModel> modelList)
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
        //private static List<SubGroup> GetSubGroupList(List<Group> groups)
        //{
        //    List<SubGroup> subgroups = new List<SubGroup>();
        //    ApiRequest<List<SubGroupIntegrationModel>> apiRequest = new ApiRequest<List<SubGroupIntegrationModel>>();
        //    foreach (Group group in groups)
        //    {
        //        var response = apiRequest.Url("..http://sso.intita.com/api/offline/group" + group.Id.ToString() + "/subgroups")
        //        .Authenticate()
        //        .Get()
        //        .Send();
        //         subgroups = ConvertToSubGroup(response.Response,groups);
        //    }
        //    return subgroups;
        //}
        //private static List<SubGroup> ConvertToSubGroup(List<SubGroupIntegrationModel> modelList, List<Group> groups)
        //{
        //    List<SubGroup> subgroups = new List<SubGroup>();
        //    foreach (var item in modelList)
        //    {
        //        subgroups.Add(new SubGroup()
        //        {
        //            Id = item.Id,
        //            Name = item.Name
        //        });

        //    }

        //    foreach (var item in subgroups)
        //    {
        //        foreach (var gItem in groups)
        //        {
        //            item.GroupId = gItem.Id;
        //        }
        //    }
        //    return subgroups;
        //}


    }
}
