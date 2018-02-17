using System.Collections.Generic;
using Schedule.IntIta.Domain.Models;

namespace Schedule.IntIta.DataAccess
{
    public interface ITimeSlotRepository
    {
        void Insert(TimeSlot item);
        TimeSlot Get(int id);
        void Update(TimeSlot modifiedItem);
        void Delete(int id);
        IEnumerable<TimeSlot> GetAll();
    }
}