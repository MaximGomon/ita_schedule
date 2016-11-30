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
        public string  Grants { get; set; }

        // convers tubject to a subject model for a view
        public ShowUserModel ConvertUserToModel(User user)
        {
            Id = user.Id;
            Login = user.Login;

            if (user.Teacher == null)
            {
                Owner = user.Student.Name;
            }
            else if (user.Student == null)
            {
                Owner = user.Teacher.Name;
            }

            Type = (UserType)Enum.Parse(typeof(UserType), user.SecurityGroup.Name);

            var i = 1;
            foreach (var grand in user.SecurityGroup.Grands)
            {
                Grants += grand.Name;
                if (i < user.SecurityGroup.Grands.Count - 1)
                {
                    Grants += ", ";
                }
                i++;
            }
            
            return this;
        }
    }
}