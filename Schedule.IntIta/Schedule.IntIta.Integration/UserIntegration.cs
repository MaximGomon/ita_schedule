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
    public class UserIntegration : IUserIntegration
    {
        public List<User> FindUsers(string searchStr)
        {
            string reqUrl = "https://sso.intita.com/api/user/search?q=" + searchStr;
            ApiRequest<List<UserIntegrativeModel>> apiRequest = new ApiRequest<List<UserIntegrativeModel>>();
            var response = apiRequest.Url(reqUrl).Authenticate().Get().Send();

            return ConvertToUser(response.Response);
        }

        public User FindUserById(int? id)
        {
            return new User(){Id = id.Value};
            throw new NotImplementedException();
        }
        private List<User> ConvertToUser(List<UserIntegrativeModel> modelList)
        {
            try
            {
                List<User> users = new List<User>();
                foreach (var integrativeUser in modelList)
                {
                    users.Add(new User()
                    {
                        Email = integrativeUser.Email,
                        FirstName = integrativeUser.FirstName,
                        LastName = integrativeUser.SecondName,
                        IntitaId = integrativeUser.Id
                    });
                }

                return users;
            }
            catch 
            {
                return new List<User>(){new User(){Email = "", FirstName = "",Id = 0, LastName = "",Login = ""}};
            }
        }
    }
}
