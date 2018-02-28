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
            
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            //List<User> testList = new List<User>();
            //testList.Add(new User()
            //{
            //    Email = "someEmail@gmail.com",
            //    FirstName = "Name",
            //    LastName = "SerName",
            //    Id = 2,
            //    Login = "SomeLogin",
            //    Password = "somePassword"
            //});
            //return testList;
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
