using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ITA.Schedule.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class UserUpdateModel : UserViewModel
    {
        [Required(ErrorMessage = "Please enter Login")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Invalid Login length")]
        [RegularExpression("^[A-Za-z0-9]+$")]
        public new string Login { get; set; }

        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,15}$", ErrorMessage = "Password should be 8 to 15 chars and include 1+ number/1+ lowercase/1+ uppercase char")]
        public new string Password { get; set; }
    }
}