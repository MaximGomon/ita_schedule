using System;
using System.Collections.Generic;
using System.Linq;
using Schedule.IntIta.DataAccess.Context;
using Schedule.IntIta.Domain.Models;


namespace Schedule.IntIta.DataAccess
{
    public class RoomRepository : IRoomRepository
    {
        public void Insert(Room item)
        {
            using (var context = new IntitaDbContext())
            {
                context.Rooms.Add(item);
                context.SaveChanges();
            }
        }

        public Room Get(int id)
        {
            using (var context = new IntitaDbContext())
            {
                var room = context.Rooms
                    .Single(s => s.Id == id);
                return room;
            }
        }

        public IEnumerable<Room> GetFreeRooms(DateTime forDate)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Room modifiedItem)
        {
            using (var context = new IntitaDbContext())
            {
                context.Rooms.Update(modifiedItem);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new IntitaDbContext())
            {
                var room = context.Rooms
                    .Single(s => s.Id == id);
                room.IsDeleted = true;
                context.SaveChanges();
            }
        }

        public IEnumerable<Room> GetAll()
        {
            using (var context = new IntitaDbContext())
            {
                return context.Rooms.ToList();
            }
        }
    }
}
