using System;
using System.Collections.Generic;
using System.Text;
using Schedule.IntIta.Domain.Models;

namespace Schedule.IntIta.BusinessLogic
{
    public interface IOfficeBusinessLogic
    {
        void Add(Office item);
        Office Read(int id);
        void Update(Office modifiedItem);
        void Delete(int id);
    }
}
