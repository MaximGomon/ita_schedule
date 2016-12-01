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
        [Required(ErrorMessage = "Please enter Login")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Invalid Login length")]
        [Remote("VerifyLogin", "Admin", ErrorMessage = "Login is already in use")]
        [RegularExpression("^[A-Za-z0-9]+$", ErrorMessage = "Login should consist of latin alphabeth chars and numbers only")]
        public virtual string Login { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,15}$", ErrorMessage = "Password should be 8 to 15 chars and include 1+ number/1+ lowercase/1+ uppercase char")]
        public virtual string Password { get; set; }

        public Guid StudentId { get; set; }
        public Guid TeacherId { get; set; }
        [Required]
        public UserType TypeOfUser { get; set; }
    }
}