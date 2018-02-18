using System;
using System.Collections.Generic;
using System.Text;
using Schedule.IntIta.Domain.Models;

namespace Schedule.IntIta.DataAccess
{
    public interface IOfficeRepository
    {
        Office Get(int id);
        void Insert(Office item);
        void Update(Office modifiedItem);
        void Delete(int id);
        IEnumerable<Office> GetAll();
    }
}
