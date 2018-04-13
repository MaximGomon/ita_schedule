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
        List<User> ReadByStr(string searchStr);
        //void Update(User modifiedUser);
        //void Delete(int id);
        List<User> GetLocalUserByStr(string searchStr);
    }
}
