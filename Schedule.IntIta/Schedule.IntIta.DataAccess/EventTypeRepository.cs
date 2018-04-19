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
        private readonly IntitaDbContext _context;

        public EventTypeRepository(IntitaDbContext context)
        {
            _context = context;
        }

        public void Insert(EventType item)
        {
            _context.EventTypes.Add(item);
            _context.SaveChanges();
        }

        public EventType Get(int id)
        {
            return _context.EventTypes.Single(x => x.Id == id);
        }

        public void Update(EventType modifiedItem)
        {
            _context.EventTypes.Update(modifiedItem);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {

            var item = _context.EventTypes.First(x => x.Id == id);
            item.IsDeleted = true;
            _context.SaveChanges();
        }

        public IEnumerable<EventType> GetAll()
        {
            return _context.EventTypes.ToList();
        }
    }
}
