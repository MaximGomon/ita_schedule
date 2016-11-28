﻿using System;
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
        // attach student to the user
        Student AttachStudent(Guid studentId);
        // attach teacher to a user
        Teacher AttachTeacher(Guid teachreId);
        // set access group
        SecurityGroup SetSecurityGroup(Guid groupId);
    }
}