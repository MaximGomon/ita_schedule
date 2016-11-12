using ITA.Schedule.BLL.Interface.Base;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.BLL.Interface
{
    interface IUserBl : ICrudBl<User>
    {
        // authorize user in the app
        User AuthorizeApp(string login, string password);
    }
}
