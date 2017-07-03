using System;
using ITA.Schedule.BLL.Interface.Base;
using ITA.Schedule.Entity.Entities;
using ITA.Schedule.Util;

namespace ITA.Schedule.BLL.Interface
{
    interface IUserBl : ICrudBl<User>
    {
        /// <summary>authorize user in the app</summary>
        User AuthorizeApp(string login, string password);

        /// <summary>create new user, get user data from HTML form</summary>
        bool CreateNewUser(string login, string password, Guid ownerId, UserType type);
        /// <summary>attach student to the user</summary>
        Student AttachStudent(Guid studentId);
        /// <summary>attach teacher to a user</summary>
        Teacher AttachTeacher(Guid teachreId);
        /// <summary>set access group</summary>
        SecurityGroup SetSecurityGroup(string groupName);
    }
}
