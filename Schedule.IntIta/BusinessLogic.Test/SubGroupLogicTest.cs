using System.Linq;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using NUnit.Framework;
using Schedule.IntIta.BusinessLogic;
using Schedule.IntIta.DataAccess;
using Schedule.IntIta.Domain.Models;
using Schedule.IntIta.Domain.Models.Enumerations;

namespace BusinessLogic.Test
{
    class SubGroupLogicTest
    {
        public void CreateSubGroupTest()
        {
            //Create test Room item
             SubGroup subgroup[ = new SubGroup()
            {
                Id = 123,
                Name = "yellow",
                IsDeleted = false,
                RoomStatus = RoomStatus.Active,
                SeatNumber = 12
            };
            //Create mock for IRoomRepository
            IRoomRepository repository = A.Fake<IRoomRepository>();

            Room resultRoom = null;
            //Mock invocation of method GetAll
            A.CallTo(() => repository.GetAll()).Returns(Enumerable.Empty<Room>());

            A.CallTo(() => repository.Insert(A<Room>.Ignored)).Invokes(call =>
            {
                resultRoom = new Room()
                {
                    Id = ((Room)call.Arguments[0]).Id
                };
            });

            //Create logic item for testing
            RoomBusinessLogic roomLogic = new RoomBusinessLogic(repository);

            roomLogic.Add(myCustomRoom);

            Assert.IsNotNull(resultRoom);
            Assert.AreEqual(myCustomRoom.Id, resultRoom.Id);
        }
    }
}
