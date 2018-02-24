using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schedule.IntIta.BusinessLogic;
using Schedule.IntIta.DataAccess;
using Schedule.IntIta.Domain.Models;
using System.Linq;

namespace BusinessLogic.Test
{
    [TestClass]
    public class UserLogicTest
    {
        [TestMethod]
        public void CreateUserTest()
        {
            User testUser = new User()
            {
                Id = 122,
                Login = "NXY",
                Email = "n.Kubliy@gmail.com",
                Password = "pass",
                LastName = "Kublii",
                FirstName = "Nazar",
                UserType = Schedule.IntIta.Domain.Models.Enumerations.UserType.Student
            };
            IUserRepository repository = A.Fake<IUserRepository>();
            User resultUser = null;
            A.CallTo(() => repository.GetAll()).Returns(Enumerable.Empty<User>());

            A.CallTo(() => repository.Insert(A<User>.Ignored)).Invokes(call =>
            {
                resultUser = new User()
                {
                    Id = ((User)call.Arguments[0]).Id
                };
            });

            UserBusinessLogic userLogic = new UserBusinessLogic(repository);

            userLogic.Add(testUser);

            Assert.IsNotNull(resultUser);
            Assert.AreEqual(testUser.Id, resultUser.Id);
        }
    }
}
