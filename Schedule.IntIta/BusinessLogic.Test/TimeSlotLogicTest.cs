using System;
using System.Linq;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schedule.IntIta.BusinessLogic;
using Schedule.IntIta.DataAccess;
using Schedule.IntIta.Domain.Models;

namespace BusinessLogic.Test
{
    [TestClass]
    public class TimeSlotLogicTest
    {
        [TestMethod]
        public void CreateTimeSlotTest()
        {
            //Create test Room item
            TimeSlot myCustomTimeSlot = new TimeSlot()
            {
                Id = 10,
                StartTime = new DateTime(2018, 5, 21),
                EndTime = new DateTime(2018, 5, 22),
                IdType = 1
            };
            //Create mock for IRoomRepository
            ITimeSlotRepository repository = A.Fake<ITimeSlotRepository>();
            ITimeSlotTypesRepository trepository = A.Fake<ITimeSlotTypesRepository>();

            TimeSlot resultTimeSlot = null;
            //Mock invocation of method GetAll
            A.CallTo(() => repository.GetAll()).Returns(Enumerable.Empty<TimeSlot>());

            A.CallTo(() => repository.Insert(A<TimeSlot>.Ignored)).Invokes(call =>
            {
                resultTimeSlot = new TimeSlot()
                {
                    Id = ((TimeSlot)call.Arguments[0]).Id
                };
            });

            //Create logic item for testing
            TimeSlotBuisnessLogic timeSlotLogic = new TimeSlotBuisnessLogic(repository, trepository);

            timeSlotLogic.Add(myCustomTimeSlot);

            Assert.IsNotNull(resultTimeSlot);
            Assert.AreEqual(myCustomTimeSlot.Id, resultTimeSlot.Id);
        }
    }
}