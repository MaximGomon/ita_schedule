using System;
using System.Collections.Generic;
using Schedule.IntIta.Domain.Models;

namespace Schedule.IntIta.DataAccess
{
    public interface ISubjectRepository
    {
        void Insert(Subject item);
        Subject Get(int id);
        IEnumerable<Subject> GetFreeRooms(DateTime forDate);
        void Update(Subject modifiedItem);
        void Delete(int id);
        IEnumerable<Subject> GetAll();
    }
}