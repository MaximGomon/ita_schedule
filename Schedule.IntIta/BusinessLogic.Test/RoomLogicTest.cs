using System.Linq;
using FakeItEasy;
using NUnit.Framework;
using Schedule.IntIta.BusinessLogic;
using Schedule.IntIta.DataAccess;
using Schedule.IntIta.Domain.Models;

namespace BusinessLogic.Test
{
    [TestFixture]
    public class RoomLogicTest
    {
        [Test]
        public void CreateRoomTest()
        {
            //Create test Room item
            Room myCustomRoom = new Room()
            {
                Id = 12
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
                    //((Room)call.Arguments[0]) get input function parameter
                    Id = ((Room)call.Arguments[0]).Id
                };
            });

            //Create logic item for testing
            RoomBusinessLogic roomLogic = new RoomBusinessLogic(repository);

            roomLogic.Add(myCustomRoom);

            Assert.NotNull(resultRoom);
            Assert.AreEqual(resultRoom.Id, myCustomRoom.Id);
        }
    }
}
