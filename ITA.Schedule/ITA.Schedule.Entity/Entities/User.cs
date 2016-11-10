using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITA.Schedule.Entity.Entities
{
    public class User : IdEntity
    {
        [MinLength(1, ErrorMessage = "Too short name. Must be 1-50 chars")]
        [MaxLength(50, ErrorMessage = "Too long name. Must be 1-50 chars")]
        [Required]
        public string Login { get; set; }

        [MinLength(1, ErrorMessage = "Too short name. Must be 1-100 chars")]
        [MaxLength(100, ErrorMessage = "Too long name. Must be 1-100 chars")]
        [Required]
        public string Password { get; set; }

        public virtual SecurityGroup SecurityGroup { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Student Student { get; set; }


    }
}
