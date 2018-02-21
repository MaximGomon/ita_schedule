using System;
using System.Collections.Generic;
using Schedule.IntIta.Domain.Models;

namespace Schedule.IntIta.DataAccess
{
    public interface IEventTypeRepository
    {
        void Insert(EventType item);
        EventType Get(int id);
        void Update(EventType modifiedItem);
        void Delete(int id);
        IEnumerable<EventType> GetAll();
    }
}
