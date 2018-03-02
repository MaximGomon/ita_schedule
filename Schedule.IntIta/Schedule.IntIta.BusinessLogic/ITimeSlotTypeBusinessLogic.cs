using Schedule.IntIta.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.IntIta.BusinessLogic
{
    public interface ITimeSlotTypeBusinessLogic
    {
        void Add(TimeSlotTypes timeSlotType);
        void Delete(int id);
        TimeSlotTypes Read(int id);
        void Update(TimeSlotTypes modifiedTimeSlot);
    }
}
