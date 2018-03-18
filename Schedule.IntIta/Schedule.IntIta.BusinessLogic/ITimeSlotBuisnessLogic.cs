using System;
using Schedule.IntIta.Domain.Models;
using System.Collections.Generic;

namespace Schedule.IntIta.BusinessLogic
{
    public interface ITimeSlotBuisnessLogic
    {
        void Add(TimeSlot timeSlot);
        void Delete(int id);
        TimeSlot Read(int id);
        void Update(TimeSlot modifiedTimeSlot);
        List<TimeSlot> GetAllTimeSlots();
        List<TimeSlotTypes> GetAllTimeSlotTypes();


    }
}