using System;
using System.Collections.Generic;
using System.Linq;
using Schedule.IntIta.DataAccess.Context;
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

        public User GetById(int? id)
        {
            return _userIntegration.FindUserById(id);
        }

        public List<User> GetByStr(string searchStr)
        {
            return _userIntegration.FindUsers(searchStr);
        }

        public List<User> GetLocalUserByStr(string searchStr)
        {
            using (var context = new IntitaDbContext())
            {
                var users = context.Users.Where(
                    x => x.FirstName.Contains(searchStr) || 
                    x.LastName.Contains(searchStr) ||
                    x.Email.Contains(searchStr))
                    .ToList();
                return users;
            }
        }

        //public IEnumerable<User> GetAll()
        //{
        //    return _userIntegration.FindUsers();
        //}

        public void Insert(User item)
        {
            using (var context = new IntitaDbContext())
            {
                context.Users.Add(item);
                context.SaveChanges();
            }
        }

        public void Update(User modifiedUser)
        {
            throw new NotImplementedException();
        }
    }
}
