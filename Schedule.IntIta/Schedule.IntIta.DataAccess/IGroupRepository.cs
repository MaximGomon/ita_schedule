using System;
using System.Collections.Generic;
using Schedule.IntIta.Domain.Models;


namespace Schedule.IntIta.DataAccess
{
    public interface IGroupRepository
    {
        void Insert(Group item);
        Group Get(int id);
        void Update(Group modifiedItem);
        void Delete(int id);
        IEnumerable<Group> GetAll();
    }
}
