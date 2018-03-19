using Schedule.IntIta.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.IntIta.BusinessLogic
{
    public interface ISubGroupBusinessLogic
    {
        void Add(SubGroup item);
        SubGroup Read(int id);
        void Update(SubGroup modifiedUser);
        void Delete(int id);

    }
}
