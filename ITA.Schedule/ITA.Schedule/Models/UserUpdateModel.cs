using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ITA.Schedule.Entity.Entities;
using ITA.Schedule.Util;

namespace ITA.Schedule.Models
{
    /// <summary>
    /// Model to update user
    /// </summary>
    public class UserUpdateModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Please enter Login")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Invalid Login length")]
        [RegularExpression("^[A-Za-z0-9]+$", ErrorMessage = "Login should consist of latin alphabeth chars and numbers only")]
        public string Login { get; set; }

        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,15}$", ErrorMessage = "Password should be 8 to 15 chars and include 1+ number/1+ lowercase/1+ uppercase char")]
        public string Password { get; set; }
        public Guid StudentId { get; set; }
        public Guid TeacherId { get; set; }
        [Required]
        public UserType TypeOfUser { get; set; }

        public UserUpdateModel UserToUserModel(User user)
        {
            Id = user.Id;
            Login = user.Login;

            if (user.Student != null)
            {
                TypeOfUser = UserType.Student;
                StudentId = user.Student.Id;
            }
            else if (user.Teacher != null)
            {
                TypeOfUser = user.SecurityGroup.Code == (int) UserType.Admin ? UserType.Admin : UserType.Teacher;

                TeacherId = user.Teacher.Id;
            }

            return this;
        }
    }
}