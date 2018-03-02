using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schedule.Intita.ApiRequest;
using Schedule.IntIta.Domain.Models;
using Schedule.IntIta.Integration;

namespace BusinessLogic.Test
{
    /*
     * Sample of using ApiRequest class
     */
    [TestClass]
    public class ApiRequestTest
    {
        [TestMethod]
        public void GetGroupsApiRequestTest()
        {
            //Create istanse of ApiRequestHelper
            ApiRequest<List<UserIntegration>> apiRequest = new ApiRequest<List<UserIntegration>>();

            //Send request
            var response = apiRequest.Url("https://sso.intita.com/api/user/search?q=m") //API url
                            .Authenticate() //add default or own authenticate
                            .Get() //GET, POST, PUT, DELETE
                            .Send(); //send request

            Assert.IsNotNull(response);

            if (response.IsDeserializeSuccess)
                Assert.IsTrue(response.Response[0] is UserIntegration ui);
        }
    }

    internal class TestGroup : IEntity
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}