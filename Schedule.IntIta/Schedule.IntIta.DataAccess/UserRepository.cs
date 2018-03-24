using System;
using System.Collections.Generic;
using System.Linq;
using Schedule.IntIta.Domain.Models;
using Schedule.IntIta.Integration;

namespace Schedule.IntIta.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserIntegration _userIntegration;
        public UserRepository(IUserIntegration userIntegration)
        {
            _userIntegration = userIntegration;
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            return _userIntegration.GetUserList().FirstOrDefault(x => x.Id == id);
        }

        public List<User> GetByStr(string searchStr)
        {
            return _userIntegration.GetUserByStr(searchStr);
        }

        public IEnumerable<User> GetAll()
        {
            return _userIntegration.GetUserList();
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
