using System.Linq;
using ITA.Schedule.DAL.Repositories.Interfaces;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.DAL.Repositories.Implementations
{
    /// <summary>
    /// Repository to perform CRUD operations over user entity
    /// </summary>
    public class UserRepository : CrudRepository<User>, IUserRepository
    {
        // returns user or null if there is no user with such login and password in the db
        public User AuthorizeApp(string login, string password)
        {
            return ContextDb.Users.FirstOrDefault(x => x.Login == login && x.Password == password);
        }
    }
}