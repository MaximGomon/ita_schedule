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
        public static List<User> GetUserList()
        {
            List<User> tmp = new List<User>();
            ApiRequest<List<UserIntegrativeModel>> apiRequest = new ApiRequest<List<UserIntegrativeModel>>();
            var response = apiRequest.Url("https://sso.intita.com/api/user/search?q=blin")
                .Authenticate()
                .Get()
                .Send();
            foreach (var integrativeUser in response.Response)
            {
                tmp.Add(new User()
                {
                    Email = integrativeUser.Email,
                    FirstName = integrativeUser.FirstName,
                    LastName = integrativeUser.SecondName,
                    Id = integrativeUser.Id
                });
            }
            return tmp;
        }
    }
}
