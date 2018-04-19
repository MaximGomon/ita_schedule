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
        private readonly IntitaDbContext _context;

        public RoomRepository(IntitaDbContext context)
        {
            _context = context;
        }

        public void Insert(Room item)
        {

            Room newRoom = new Room()
            {
                Name = item.Name,
                SeatNumber = item.SeatNumber,
                OfficeId = item.OfficeId,
                IsDeleted = item.IsDeleted,
                RoomStatus = item.RoomStatus,
            };
            _context.Rooms.Add(newRoom);
            _context.SaveChanges();

        }

        public Room Get(int id)
        {
            var room = _context.Rooms
                .Single(s => s.Id == id);
            return room;
        }

        public IEnumerable<Room> GetFreeRooms(DateTime forDate)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Room modifiedItem)
        {
            _context.Rooms.Update(modifiedItem);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var room = _context.Rooms
                .Single(s => s.Id == id);
            room.IsDeleted = true;
            _context.SaveChanges();
        }

        public IEnumerable<Room> GetAll()
        {
            return _context.Rooms.ToList();
        }
    }
}
