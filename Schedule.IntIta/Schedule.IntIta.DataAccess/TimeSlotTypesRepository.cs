using System.Collections.Generic;
using Schedule.IntIta.Domain.Models;
using Schedule.IntIta.DataAccess.Context;
using System.Linq;
using System;

namespace Schedule.IntIta.DataAccess
{
    public class TimeSlotTypesRepository : ITimeSlotTypesRepository
    {
        public void Delete(int id)
        {
            using (var context = new IntitaDbContext())
            {
                var removedTimeslotType = context.TimeSlotTypes.Find(id);
                context.TimeSlotTypes.Remove(removedTimeslotType);
            }
                
        }

        public TimeSlotTypes Get(int id)
        {
            using (var context = new IntitaDbContext())
            {
                var type = context.TimeSlotTypes.Find(id);
                return type;
            }
        }

        public IEnumerable<TimeSlotTypes> GetAll()
        {
            using (var context = new IntitaDbContext())
            {
                IEnumerable<TimeSlotTypes> timeSlotTypesList = context.TimeSlotTypes.ToList();
                return timeSlotTypesList;
            }
            
        }

        public void Insert(TimeSlotTypes item)
        {
            using (var context = new IntitaDbContext())
            {
                context.TimeSlotTypes.Add(item);
                context.SaveChanges();
            }
               
        }

        public void Update(TimeSlotTypes modifiedItem)
        {
            using (var context = new IntitaDbContext())
            {
                var oldTimeSlotType = context.TimeSlotTypes.Find(modifiedItem.Id);
                oldTimeSlotType.Id = modifiedItem.Id;
                oldTimeSlotType.Type = modifiedItem.Type;
                context.SaveChanges();
            }
           
        }
    }
}
