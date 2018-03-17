using System.Linq;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using NUnit.Framework;
using Schedule.IntIta.BusinessLogic;
using Schedule.IntIta.DataAccess;
using Schedule.IntIta.Domain.Models;
using Schedule.IntIta.Domain.Models.Enumerations;
//using Assert = NUnit.Framework.Assert;

namespace BusinessLogic.Test
{
    //[TestFixture]
    [TestClass]
    public class RoomLogicTest
    {
        //[Test]
        [TestMethod]
        public void CreateRoomTest()
        {
            //Create test Room item
            Room myCustomRoom = new Room()
            {
                Id = 12,
                Name = "TEst",
                IsDeleted = false,
                RoomStatus = RoomStatus.Active,
                SeatNumber = 12,
                OfficeId = 1
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
