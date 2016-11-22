using System.Collections.Generic;

namespace ITA.Schedule.Models
{
    /// <summary>
    /// Model contains list of teachers to display in Admin View
    /// </summary>
    public class TeacherListViewModel
    {
        public IEnumerable<TeacherModel> Teachers { get; set; }
    }
}