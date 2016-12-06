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
    public class FilterViewModel
    {

        public DateTime StartDateTime { get; set; }

        /// <summary>
        /// Subject ID for student or Group ID for teacher
        /// </summary>
        public string FirstId { get; set; }

        
        /// <summary>
        /// Teacher ID for student or Subgroup ID for teacher
        /// </summary>
        public Guid SecondId { get; set; }

        /// <summary>
        /// List of subjects for user or list of groups for teacher
        /// </summary>
        public List<SelectListItem> FirstList { get; set; }

        /// <summary>
        /// List of Teachers for user or list of subGroups for teacher
        /// </summary>
        public List<SelectListItem> SecondList { get; set; }

        public TimePeriod MyTimePeriod { get; set; }

    }
}