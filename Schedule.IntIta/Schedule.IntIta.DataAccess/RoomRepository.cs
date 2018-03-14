using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Schedule.IntIta.DataAccess.Context;
using Schedule.IntIta.Domain.Models;


namespace Schedule.IntIta.DataAccess
{
    public class RoomRepository : IRoomRepository
    {
        public void Insert(Room item)
        {
            //using (var context = new IntitaDbContext())
            //{
            //    context.Rooms.Add(item);
            //    context.SaveChanges();
            //}
            using (var context = new IntitaDbContext())
            {
                Room newRoom = new Room()
                {
                    Name = item.Name,
                    SeatNumber = item.SeatNumber,
                    OfficeId = item.OfficeId,
                    IsDeleted = item.IsDeleted,
                    RoomStatus = item.RoomStatus,
                };
                context.Rooms.Add(newRoom);
                //newRoom.OfficeId = context.Office.First(x => x.Id == item.O.Id);//context.Office.First(x => x.Id == item.OfficeId);
                context.SaveChanges();
            }
            //using (var context = new IntitaDbContext())
            //{
            //    Room newRoom = new Room()
            //    {
            //        Name = item.Name,
            //        SeatNumber = item.SeatNumber,
            //        Office = item.Office,
            //        IsDeleted = item.IsDeleted,
            //        RoomStatus = item.RoomStatus,
            //    };
            //    context.Rooms.Add(newRoom);
            //    newRoom.Office = context.Office.First(x => x.Id == item.Office.Id);
            //    context.SaveChanges();
            //}
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
                //modifiedItem.OfficeId = context.Office.Single(x => x.Id == modifiedItem.OfficeId);
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
            //using (var context = new IntitaDbContext())
            //{
            //    var result = context.Rooms
            //        .Include(p => p.Office);
            //    return result.ToList();
            //}
        }
    }
}
