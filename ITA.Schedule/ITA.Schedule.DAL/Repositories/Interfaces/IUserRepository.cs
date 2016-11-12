using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.DAL.Repositories.Interfaces
{
    /// <summary>
    /// Interface to be implemented by TeacherRepository
    /// </summary>
    public interface IUserRepository : ICrudRepository<User>
    {
        // authorize user in the app
        User AuthorizeApp(string login, string password);
    }
}