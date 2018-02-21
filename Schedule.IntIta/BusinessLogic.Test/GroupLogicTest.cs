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
    class GroupLogicTest
    {
        public void CreateGroup[Test()
        {
            //Create test Room item
            Group myGroup = new Group[()
            {
                Id = 12,
                Name = "A-17",
                NumberOfStudents = 40,
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
