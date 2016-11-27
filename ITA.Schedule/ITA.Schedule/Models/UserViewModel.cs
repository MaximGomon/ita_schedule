using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ITA.Schedule.Util;

namespace ITA.Schedule.Models
{
    public class UserViewModel
    {
        [MinLength(1, ErrorMessage = "Too short name. Must be 1-50 chars")]
        [MaxLength(50, ErrorMessage = "Too long name. Must be 1-50 chars")]
        [Required]
        public string Login { get; set; }

        [MinLength(1, ErrorMessage = "Too short password. Must be 1-100 chars")]
        [MaxLength(100, ErrorMessage = "Too long password. Must be 1-100 chars")]
        [Required]
        public string Password { get; set; }

        public Guid StudentId { get; set; }
        public Guid TeacherId { get; set; }
    }
}