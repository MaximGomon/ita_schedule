using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schedule.IntIta.DataAccess;
using Schedule.IntIta.Domain.Models;
using Schedule.IntIta.Domain.Models.Enumerations;
using Schedule.IntIta.ViewModels;

namespace BusinessLogic.Test
{
    [TestClass]
    public class AutoMapperTest
    {
        [TestMethod]
        public void UserMappingTest()
        {
            User user = new User()
            {
                Email = "some@some.com",
                Id = 1,
                FirstName = "name",
                LastName = "soname",
                Grants = new Grant[]
                {
                    new Grant(), 
                    new Grant(), 
                },
                Login = "login",
                Password = "password",
                UserType = UserType.Admin
            };

            var result = _mapper.Map<Room>(userViewModel);


        }
    }
}