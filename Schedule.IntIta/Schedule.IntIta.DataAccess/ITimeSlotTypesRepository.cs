using Schedule.IntIta.Domain.Models;
using System.Collections.Generic;


namespace Schedule.IntIta.DataAccess
{
    public interface ITimeSlotTypesRepository
    {
        void Insert(TimeSlotTypes item);
        TimeSlotTypes Get(int id);
        void Update(TimeSlotTypes modifiedItem);
        void Delete(int id);
        IEnumerable<TimeSlotTypes> GetAll();
    }
}
