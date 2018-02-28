using System;
using System.Collections.Generic;
using Schedule.IntIta.Domain.Models;
using Schedule.IntIta.Integration;

namespace Schedule.IntIta.DataAccess
{
    public class UserRepository : IUserRepository
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            return UserIntegration.GetUserList().Find(x => x.Id == id);
        }

        public List<User> GetByStr(string searchStr)
        {
            return UserIntegration.GetUserByStr(searchStr);
        }

        public IEnumerable<User> GetAll()
        {
            return UserIntegration.GetUserList();
        }

        public void Insert(User item)
        {
            throw new NotImplementedException();
        }

        public void Update(User modifiedUser)
        {
            throw new NotImplementedException();
        }
    }
}
