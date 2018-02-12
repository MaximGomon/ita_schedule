using System;
using System.Collections.Generic;
using Schedule.IntIta.Domain.Models;

namespace Schedule.IntIta.DataAccess
{
    public interface IRoomRepository
    {
        void Insert(Room item);
        Room Get(int id);
        IEnumerable<Room> GetFreeRooms(DateTime forDate);
        void Update(Room modifiedItem);
        void Delete(int id);
        IEnumerable<Room> GetAll();
    }
}