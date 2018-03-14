using System.Collections.Generic;
using Schedule.IntIta.Domain.Models;

namespace Schedule.IntIta.BusinessLogic
{
    public interface IRoomBusinessLogic
    {
        void Add(Room item);
        Room Read(int id);
        void Update(Room modifiedItem);
        void Delete(int id);
        IEnumerable<Room> GetAll();
    }
}
