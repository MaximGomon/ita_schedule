using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITA.Schedule.Models
{
    public class PeopleViewModel
    {

        public string Name { get; set; }
        public string Position { get; set; }
        public int Expierience { get; set; }
        public string PhotoUri { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string About { get; set; }
        public string FacebookUrl { get; set; }
        public string VkUrl { get; set; }
        public string GithubUrl { get; set; }
        public ICollection<TeacherAllTime> TeacherAllTimes { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public SubGroup SubGroup { get; set; }

    }
}