using System.Collections.Generic;
using Schedule.IntIta.Domain.Models;

namespace Schedule.IntIta.DataAccess
{
    public interface IUserRepository
    {
        void Insert(User item);
        User GetById(int? id);
        List<User> GetByStr(string searchStr);
        void Update(User modifiedUser);
        void Delete(int id);
        //IEnumerable<User> GetAll();
    }
}
