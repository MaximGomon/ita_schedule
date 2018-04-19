using System.Collections.Generic;
using Schedule.IntIta.Domain.Models;
using Schedule.IntIta.DataAccess.Context;
using System.Linq;

namespace Schedule.IntIta.DataAccess
{
    public class TimeSlotRepository : ITimeSlotRepository
    {
        private readonly IntitaDbContext _context;

        public void Insert(TimeSlot item)
        {
            _context.TimeSlots.Add(item);
            _context.SaveChanges();
        }

        public TimeSlot Get(int id)
        {

            var timeslot = _context.TimeSlots.Find(id);
            return timeslot;
        }

        public void Update(TimeSlot modifiedItem)
        {
            var oldTimeSlot = _context.TimeSlots.Find(modifiedItem.Id);
            oldTimeSlot.IdType = modifiedItem.IdType;
            oldTimeSlot.StartTime = modifiedItem.StartTime;
            oldTimeSlot.EndTime = modifiedItem.EndTime;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var deletableItem = _context.TimeSlots.Find(id);
            deletableItem.IsDeleted = true;
            _context.SaveChanges();
        }

        public IEnumerable<TimeSlot> GetAll()
        {
            IEnumerable<TimeSlot> timeslotList = _context.TimeSlots.ToList();
            return timeslotList;
        }
    }
}