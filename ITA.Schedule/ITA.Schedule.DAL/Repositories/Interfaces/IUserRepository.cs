using System;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.DAL.Repositories.Interfaces
{
    /// <summary>
    /// Interface to be implemented by TeacherRepository
    /// </summary>
    public interface IUserRepository : ICrudRepository<User>
    {
        /// <summary>authorize user in the app</summary>
        User AuthorizeApp(string login, string password);
        /// <summary>get user by login-email to avoid register user with same email</summary>
        User GetByLogin(string login);
        /// <summary>attach student to the user</summary>
        Student AttachStudent(Guid studentId);
        /// <summary>attach teacher to a user</summary>
        Teacher AttachTeacher(Guid teachreId);
        /// <summary>set access group</summary>
        SecurityGroup SetSecurityGroup(string groupName);
    }
}