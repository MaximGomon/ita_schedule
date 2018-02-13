using Schedule.IntIta.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.IntIta.BusinessLogic
{
    public interface IUserBusinessLogic
    {
        void Add(User item);
        User Read(int id);
        void Update(User modifiedItem);
        void Delete(int id);
    }
}
