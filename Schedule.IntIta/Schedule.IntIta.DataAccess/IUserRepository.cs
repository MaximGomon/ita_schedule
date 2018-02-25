using System.Collections.Generic;
using Schedule.IntIta.Domain.Models;

namespace Schedule.IntIta.DataAccess
{
    public interface IUserRepository
    {
        void Insert(User item);
        User Get(int id);
        void Update(User modifiedUser);
        void Delete(int id);
        IEnumerable<User> GetAll();
    }
}
