using System;
using System.Collections.Generic;
using Schedule.IntIta.DataAccess;
using Schedule.IntIta.DataAccess.Context;
using Schedule.IntIta.Domain.Models;

namespace Schedule.IntIta.DataAccess
{
    public class EventRepository : IEventRepository
    {
        public void Insert(Event item)
        {
            using (var context = new IntitaDbContext())
            {
                context.Events.Add(item);
                context.SaveChanges();
            }
        }

        public Event Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Event modifiedItem)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Event> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
