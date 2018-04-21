using System.Collections.Generic;
using Schedule.IntIta.Domain.Models;
using Schedule.IntIta.DataAccess.Context;
using System.Linq;
using System;

namespace Schedule.IntIta.DataAccess
{
    public class TimeSlotTypesRepository : ITimeSlotTypesRepository
    {
        private readonly IntitaDbContext _context;

        public TimeSlotTypesRepository(IntitaDbContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            var removedTimeslotType = _context.TimeSlotTypes.Find(id);
            _context.TimeSlotTypes.Remove(removedTimeslotType);
        }

        public TimeSlotTypes Get(int id)
        {
            var type = _context.TimeSlotTypes.Find(id);
            return type;
        }

        public IEnumerable<TimeSlotTypes> GetAll()
        {
            IEnumerable<TimeSlotTypes> timeSlotTypesList = _context.TimeSlotTypes.ToList();
            return timeSlotTypesList;
        }

        public void Insert(TimeSlotTypes item)
        {
            _context.TimeSlotTypes.Add(item);
            _context.SaveChanges();
        }

        public void Update(TimeSlotTypes modifiedItem)
        {
            var oldTimeSlotType = _context.TimeSlotTypes.Find(modifiedItem.Id);
            oldTimeSlotType.Id = modifiedItem.Id;
            oldTimeSlotType.Type = modifiedItem.Type;
            _context.SaveChanges();
        }
    }
}
