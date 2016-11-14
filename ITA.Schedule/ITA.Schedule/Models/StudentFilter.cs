using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITA.Schedule.Models
{
    public class StudentFilter
    {

        [DataType(DataType.Date)]
        public DateTime FromDateTime { get; set; }

        [DataType(DataType.Date)]
        public DateTime ToDateTime { get; set; }

    }
}