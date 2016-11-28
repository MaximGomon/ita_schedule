using System;
using ITA.Schedule.BLL.Interface.Base;
using ITA.Schedule.Entity.Entities;
using ITA.Schedule.Util;

namespace ITA.Schedule.BLL.Interface
{
    interface IUserBl : ICrudBl<User>
    {
        // authorize user in the app
        User AuthorizeApp(string login, string password);

        // create new user, get user data from HTML form
        bool CreateNewUser(string login, string password, Guid ownerId, Guid groupId, UserType type);
    }
}
