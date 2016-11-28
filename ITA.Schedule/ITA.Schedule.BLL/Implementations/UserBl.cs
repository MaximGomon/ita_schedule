using System;
using System.Linq;
using ITA.Schedule.BLL.Implementations.Base;
using ITA.Schedule.BLL.Interface;
using ITA.Schedule.DAL.Repositories.Interfaces;
using ITA.Schedule.Entity.Entities;
using ITA.Schedule.Util;

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

        // create new user and insert to the Db
        public bool CreateNewUser(string login, string password, Guid ownerId, Guid groupId, UserType type)
        {
            var user = new User();
            // check if unique login
            if (login == null || Repository.Get(x => x.Login == login).FirstOrDefault() != null)
            {
                return false;
            }
            user.Login = login;

            // if entered password
            if (password == null)
            {
                return false;
            }
            user.Password = password;

            // attach student to the user, if it is a user
            if (type == UserType.Student)
            {
                var student = Repository.AttachStudent(ownerId);
                if (student == null)
                {
                    return false;
                }
                user.Student = student;
            }
            // attach teacher to the user, if it is a user
            else if (type == UserType.Teacher)
            {
                var teacher = Repository.AttachTeacher(ownerId);
                if (teacher == null)
                {
                    return false;
                }
                user.Teacher = teacher;
            }
            // if something is wrong with the user type
            else
            {
                return false;
            }

            var accessGroup = Repository.SetSecurityGroup(groupId);

            // check security group
            if (accessGroup == null)
            {
                return false;
            }
            user.SecurityGroup = accessGroup;

            Insert(user);
            
            return true;
        }
    }
}
