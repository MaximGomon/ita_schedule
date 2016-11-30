using System;
using System.Collections.Generic;
using ITA.Schedule.Entity.Entities;
using ITA.Schedule.Util;

namespace ITA.Schedule.Models
{
    /// <summary>
    /// Model to display UserList
    /// </summary>
    public class ShowUserModel
    {
        public Guid Id { get; set; }
        public string Owner { get; set; }
        public string Login { get; set; }
        public UserType Type { get; set; }
        public string  UserSecurityGroup { get; set; }

        // convers tubject to a subject model for a view
        public ShowUserModel ConvertUserToModel(User user)
        {
            Id = user.Id;
            Login = user.Login;

            if (user.Teacher == null)
            {
                Owner = user.Student.Name;
                Type = UserType.Student;
            }
            else if (user.Student == null)
            {
                Owner = user.Teacher.Name;
                Type = UserType.Teacher;
            }

            UserSecurityGroup = user.SecurityGroup.Name;
            
            return this;
        }
    }
}