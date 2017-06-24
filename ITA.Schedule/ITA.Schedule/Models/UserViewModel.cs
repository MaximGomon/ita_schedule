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
        [Required(ErrorMessage = "Please enter your Email")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Invalid Email length")]
        [Remote("VerifyLogin", "Admin", ErrorMessage = "Login is already in use")]
        [RegularExpression(@"^ ([\w -\.] +)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", 
            ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "Invalid Login length")]
        [RegularExpression("^[A-Za-z0-9]+$", ErrorMessage = "Password should be from 6 to 15 chars")] 
        // and include 1+ number/1+ lowercase/1+ uppercase char")]
        //" ^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{6,15}$"
        public string Password { get; set; }

        public Guid StudentId { get; set; }
        public Guid TeacherId { get; set; }
        [Required]
        public UserType TypeOfUser { get; set; }
    }
}