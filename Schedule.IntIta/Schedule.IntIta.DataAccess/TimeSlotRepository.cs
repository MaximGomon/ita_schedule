using System.Collections.Generic;
using Schedule.IntIta.Domain.Models;
using Schedule.IntIta.DataAccess.Context;
using System.Linq;

namespace Schedule.IntIta.DataAccess
{
    public class TimeSlotRepository : ITimeSlotRepository
    {
        public void Insert(TimeSlot item)
        {
            using (var context = new IntitaDbContext())
            {
                context.TimeSlots.Add(item);
                context.SaveChanges();
            }
            
        }
        
        public TimeSlot Get(int id)
        {
            using (var context = new IntitaDbContext())
            {
                var timeslot = context.TimeSlots.Find(id);
                return timeslot;
            }
        }

        public void Update(TimeSlot modifiedItem)
        {
            using (var context = new IntitaDbContext())
            {
                var oldTimeSlot = context.TimeSlots.Find(modifiedItem.Id);
                oldTimeSlot.IdType = modifiedItem.IdType;
                oldTimeSlot.StartTime = modifiedItem.StartTime;
                oldTimeSlot.EndTime = modifiedItem.EndTime;
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new IntitaDbContext())
            {
                var deletableItem = context.TimeSlots.Find(id);
                deletableItem.IsDeleted = true;
                context.SaveChanges();
            }
               
        }

        public IEnumerable<TimeSlot> GetAll()
        {
            using (var context = new IntitaDbContext())
            {
                IEnumerable<TimeSlot> timeslotList = context.TimeSlots.ToList();
                return timeslotList;
            }
               
        }
    }
}