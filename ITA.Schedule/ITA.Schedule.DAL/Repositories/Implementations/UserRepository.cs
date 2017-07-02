﻿using System;
using System.Data.Entity;
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
        /// <summary>returns user or null if there is no user with such login and password in the db</summary>
        public User AuthorizeApp(string login, string password)
        {
            return Get(x => x.Login == login && x.Password == password).FirstOrDefault();
        }

        public User GetByLogin(string login)
        {
            return Get(x => x.Login == login).FirstOrDefault();
        }

        /// <summary>attach student to a user</summary>
        public Student AttachStudent(Guid studentId)
        {
            return ContextDb.Students.FirstOrDefault(x => x.Id == studentId);
        }

        /// <summary>attach teacher to a user</summary>
        public Teacher AttachTeacher(Guid teachreId)
        {
            return ContextDb.Teachers.FirstOrDefault(x => x.Id == teachreId);
        }

        /// <summary>set access group</summary>
        public SecurityGroup SetSecurityGroup(string groupName)
        {
            return ContextDb.SecurityGroups.FirstOrDefault(x => x.Name == groupName);
        }

        public override User GetById(Guid id)
        {
            return base.Get(x => x.Id == id)
                .Include(x => x.Teacher)
                .Include(x => x.Student)
                .Include(x => x.SecurityGroup)
                .FirstOrDefault();
        }
    }
}