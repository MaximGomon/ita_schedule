using System;
using System.Collections.Generic;
using System.Text;
using Schedule.IntIta.Domain.Models;

namespace Schedule.IntIta.BusinessLogic
{
    public interface IGroupBusinessLogic
    {
        void Add(Group item);
        Group Read(int id);
        void Update(Group modifiedUser);
        void Delete(int id);

    }
}
