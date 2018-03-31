using System;
using System.Collections.Generic;
using Schedule.IntIta.Domain.Models;

namespace Schedule.IntIta.DataAccess
{
    public interface IEventRepository
    {
        void Insert(Event item);
        Event Get(int id);
        void Update(Event modifiedItem);
        void Delete(int id);
        IEnumerable<Event> GetAll();
        IEnumerable<Event> GetActive();
    }
}
