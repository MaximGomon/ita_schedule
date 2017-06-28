using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITA.Schedule.Entity.Entities;
using ITA.Schedule.Util;

namespace ITA.Schedule.Models
{
    /// <summary>
    /// User base model
    /// </summary>
    public class UserViewModel
    {
        [Required(ErrorMessage = "Enter your Email addres")]
        //[Remote("VerifyLogin", "Admin", ErrorMessage = "Login is already in use")]
        [RegularExpression(@"^(([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)(\s*;\s*|\s*$))*$",
            ErrorMessage = "The email was entered incorrectly! Check it and  enter valid email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter your Password")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "Password should be at least 6 characters and not longer than 15 characters")]
        [RegularExpression("^[A-Za-z0-9]+$", ErrorMessage = "Password should be without special characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "First name your first name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "First name should be at least 3 characters and not longer than 50 characters")]
        [RegularExpression("^[A-Za-z0-9]+$", ErrorMessage = "FirstName should be without special characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name your first name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Last name should be at least 3 characters and not longer than 50 characters")]
        [RegularExpression("^[A-Za-z0-9]+$", ErrorMessage = "Last Name should be without special characters")]
        public string LastName { get; set; }

        public enum _roles
        {
            [Display(Name = "Student")]
            Student,
            [Display(Name = "Teacher")]
            Teacher,
        }
        [Required(ErrorMessage = "Choose your role")]
        public _roles Role { get; set;}

        public Guid StudentId { get; set; }
        public Guid TeacherId { get; set; }
        [Required]
        public UserType TypeOfUser { get; set; }
    }
}