using ITA.Schedule.BLL.Implementations.Base;
using ITA.Schedule.BLL.Interface;
using ITA.Schedule.DAL.Repositories.Interfaces;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.BLL.Implementations
{
    public class UserBl : CrudBll<IUserRepository, User>, IUserBl
    {
        public UserBl(IUserRepository repository) : base(repository)
        {
        }

        public User AuthorizeApp(string login, string password)
        {
            return Repository.AuthorizeApp(login, password);
        }
    }
}
