using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schedule.Intita.ApiRequest;

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
            ApiRequest apiRequest = new ApiRequest();

            //Send request
            var response = apiRequest.Url("https://sso.intita.com/api/offline/groups") //API url
                            .Authenticate() //add default or own authenticate
                            .Get() //GET, POST, PUT, DELETE
                            .Send(); //send request

            Assert.IsNotNull(response);
        }
    }
}