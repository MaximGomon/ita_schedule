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
    public class UserIntegration
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("middleName")]
        public string MiddleName { get; set; }

        [JsonProperty("secondName")]
        public string SecondName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

     
        public static List<User> GetUserList()
        {
            List<User> tmp = new List<User>();
            ApiRequest<List<UserIntegrativeModel>> apiRequest = new ApiRequest<List<UserIntegrativeModel>>();
            var response = apiRequest.Url("https://sso.intita.com/api/user/search?q=blin")
                .Authenticate()
                .Get()
                .Send();
            tmp = ConvertToUser(response.Response);
            return tmp;
        }

        public static List<User> GetUserByStr(string searchStr)
        {
            string reqUrl = "https://sso.intita.com/api/user/search?q=" + searchStr;
            ApiRequest<List<UserIntegrativeModel>> apiRequest = new ApiRequest<List<UserIntegrativeModel>>();
            var response = apiRequest.Url(reqUrl).Authenticate().Get().Send();

            return ConvertToUser(response.Response);
        }

        private static List<User> ConvertToUser(List<UserIntegrativeModel> modelList)
        {
            List<User> users = new List<User>();
            foreach (var integrativeUser in modelList)
            {
                users.Add(new User()
                {
                    Email = integrativeUser.Email,
                    FirstName = integrativeUser.FirstName,
                    LastName = integrativeUser.SecondName,
                    Id = integrativeUser.Id
                });
            }

            return users;
        }
    }
}
