using System;
using System.Collections.Generic;
using Schedule.IntIta.Domain.Models;


namespace Schedule.IntIta.DataAccess
{
    public interface ISubGroupRepository
    {
        void Insert(SubGroup item);
        SubGroup Get(int id);
        void Update(SubGroup modifiedItem);
        void Delete(int id);
        IEnumerable<SubGroup> GetAll();
    }
}

