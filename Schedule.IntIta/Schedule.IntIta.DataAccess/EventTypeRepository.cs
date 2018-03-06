using System;
using System.Collections.Generic;
using System.Linq;
using Schedule.IntIta.DataAccess;
using Schedule.IntIta.DataAccess.Context;
using Schedule.IntIta.Domain.Models;

namespace Schedule.IntIta.DataAccess
{
    public class EventTypeRepository : IEventTypeRepository
    {
        public void Insert(EventType item)
        {
            throw new System.NotImplementedException();
        }

        public EventType Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(EventType modifiedItem)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<EventType> GetAll()
        {
            using (var context = new IntitaDbContext())
            {
                return context.EventTypes.ToList();
            }
        }
    }
}
