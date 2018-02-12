using System;
using System.Collections.Generic;
using Schedule.IntIta.Domain.Models;


namespace Schedule.IntIta.DataAccess
{
    public class RoomRepository : IRoomRepository
    {
        public void Insert(Room item)
        {
            throw new System.NotImplementedException();
        }

        public Room Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Room> GetFreeRooms(DateTime forDate)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Room modifiedItem)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Room> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
