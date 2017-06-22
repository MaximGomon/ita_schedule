using System;
using System.Linq;
using ITA.Schedule.BLL.Implementations.Base;
using ITA.Schedule.BLL.Interface;
using ITA.Schedule.DAL.Repositories.Interfaces;
using ITA.Schedule.Entity.Entities;
using ITA.Schedule.Util;
using NLog;

namespace ITA.Schedule.BLL.Implementations
{
    public class UserBl : CrudBll<IUserRepository, User>, IUserBl
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        public UserBl(IUserRepository repository) : base(repository)
        {
        }

        public User AuthorizeApp(string login, string password)
        {
            _logger.Info("AuthorizeApp ({0} , {1})", login, password);
            return Repository.AuthorizeApp(login, password);
        }

        // create new user and insert to the Db
        public bool CreateNewUser(string login, string password, Guid ownerId, UserType type)
        {
            _logger.Info("CreateNewUser ({0} , {1} , {2} , {3})", login, password, ownerId, type);
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
                var student = AttachStudent(ownerId);
                if (student == null)
                {
                    return false;
                }
                user.Student = student;
            }
            // attach teacher to the user, if it is a user
            else if (type == UserType.Teacher || type == UserType.Admin)
            {
                var teacher = AttachTeacher(ownerId);
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

            var accessGroup = SetSecurityGroup(type.ToString());

            // check security group
            if (accessGroup == null)
            {
                return false;
            }
            user.SecurityGroup = accessGroup;

            Insert(user);
            
            return true;
        }

        // attach student to the user
        public Student AttachStudent(Guid studentId)
        {
            _logger.Info("AttachStudent ({0})", studentId);
            return Repository.AttachStudent(studentId);
        }

        // attache teacher to the user
        public Teacher AttachTeacher(Guid teachreId)
        {
            _logger.Info("AttachTeacher ({0})", teachreId);
            return Repository.AttachTeacher(teachreId);
        }

        // set user security group
        public SecurityGroup SetSecurityGroup(string groupName)
        {
            _logger.Info("SetSecurityGroup ({0})", groupName);
            return Repository.SetSecurityGroup(groupName);
        }
    }
}
