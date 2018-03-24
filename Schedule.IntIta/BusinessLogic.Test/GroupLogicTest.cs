using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schedule.IntIta.BusinessLogic;
using Schedule.IntIta.DataAccess;
using Schedule.IntIta.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using Schedule.Intita.ApiRequest;
using Schedule.IntIta.Integration;
using Schedule.IntIta.Integration.IntegrationModels;

namespace BusinessLogic.Test
{
    [TestClass]
    public class GroupLogicTest
    {
        [TestMethod]
        public void CreateGroupMethod()
        {

            SubGroup testSubgroup = new SubGroup
            {
                Id = 1,
                Name = "Green",
                NumberOfStudents = 7,
                GroupId = 10,
                SubGroupTimeSlot = new TimeSlot()
            };
            SubGroup testSubgroup1 = new SubGroup
            {
                Id = 2,
                Name = "Yellow",
                GroupId = 10,
                NumberOfStudents = 8,
                SubGroupTimeSlot = new TimeSlot()
            };
            SubGroup testSubgroup2 = new SubGroup
            {
                Id = 3,
                Name = "E6",
                GroupId = 10,
                NumberOfStudents = 10,
                SubGroupTimeSlot = new TimeSlot()
            };

            Group testGroup = new Group
            {
                Id = 10,
                Name = "A17",
                NumberOfStudents = 25,
                Subgroups = new List<SubGroup>(){ testSubgroup,testSubgroup1,testSubgroup2 }
            };

            IGroupRepository groupRepo = A.Fake<IGroupRepository>();
            Group resultGroup = null;
            A.CallTo(() => groupRepo.GetAll()).Returns(Enumerable.Empty<Group>());
            A.CallTo(() => groupRepo.Insert(A<Group>.Ignored)).Invokes(call =>
            {
                resultGroup = new Group()
                {
                    Id = ((Group)call.Arguments[0]).Id
                };
            });

            GroupBusinessLogic groupLogic = new GroupBusinessLogic(groupRepo);
            groupLogic.Add(testGroup);

            Assert.IsNotNull(resultGroup);
            Assert.AreEqual(testGroup.Id, resultGroup.Id);
        }

        //public void GroupIntegrationTest()
        //{
        //    var apiGroupHandler = A.Fake<ApiRequest<GroupIntegrationModel>>();
        //    A.CallTo(() => apiGroupHandler.Get()).Returns(null);
        //    A.CallTo(() => apiGroupHandler.Authenticate()).Returns(null);
        //    A.CallTo(() => apiGroupHandler.Send()).Returns(new ApiResponse<GroupIntegrationModel>()
        //    {
        //        Response = new GroupIntegrationModel()
        //        {
        //            Name = "A17",
        //            Id = 10
        //        }
        //    });
        //    IGroupIntegrationHandler integrationHandler = A.Fake<IGroupIntegrationHandler>();
        //    var result = integrationHandler.GetGroupList();
        //}
    }
}
