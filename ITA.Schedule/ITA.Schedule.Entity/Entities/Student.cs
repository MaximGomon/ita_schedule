using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITA.Schedule.Entity.Entities
{
    public class Student : NamedEntity
    {
        //[MinLength(1, ErrorMessage = "Too short name. Must be 1-100 chars")]
        //[MaxLength(100, ErrorMessage = "Too long name. Must be 1-100 chars")]
        //[Required]
        //public string FirstName { get; set; }

        //[MinLength(1, ErrorMessage = "Too short name. Must be 1-100 chars")]
        //[MaxLength(100, ErrorMessage = "Too long name. Must be 1-100 chars")]
        //[Required]
        //public string LastName { get; set; }

        //[MinLength(1, ErrorMessage = "Too short name. Must be 1-100 chars")]
        //[MaxLength(100, ErrorMessage = "Too long name. Must be 1-100 chars")]
        //public string SurName { get; set; }

        //[Required]
        //[Column(TypeName = "datetime2")]
        //public DateTime BirthdayDate { get; set; }

        //public int Phone { get; set; }

        //[MinLength(1, ErrorMessage = "Too short name. Must be 1-100 chars")]
        //[MaxLength(100, ErrorMessage = "Too long name. Must be 1-100 chars")]
        //public string Address { get; set; }

        public virtual SubGroup SubGroup { get; set; }

 
    }
}
