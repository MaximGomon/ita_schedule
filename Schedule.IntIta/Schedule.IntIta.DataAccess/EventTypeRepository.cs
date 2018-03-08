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
            using (var context = new IntitaDbContext())
            {
                context.EventTypes.Add(item);
                context.SaveChanges();
            }
        }

        public EventType Get(int id)
        {
            using (var context = new IntitaDbContext())
            {
                return context.EventTypes.Single(x => x.Id == id);
            }
        }

        public void Update(EventType modifiedItem)
        {
            using (var context = new IntitaDbContext())
            {
                context.EventTypes.Update(modifiedItem);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new IntitaDbContext())
            {
                var item = context.EventTypes.First(x => x.Id == id);
                item.IsDeleted = true;
                context.SaveChanges();
            }
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
