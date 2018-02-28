using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Http;
using Schedule.Intita.ApiRequest;
using Schedule.IntIta.Domain.Models;
using Newtonsoft.Json;
using Schedule.Intita.ApiRequest.Enumerations;

namespace Schedule.IntIta.Integration
{
    public class UserIntegration
    { 
        public static List<User> GetUserList()
        {
            ApiRequest<List<User>> apiRequest = new ApiRequest<List<User>>();
            var response = apiRequest.Url("http://localhost:53649/Search/result")
                .Authenticate()
                .Get()
                .Send();
            

            return response.Response;
        }
    }
}
