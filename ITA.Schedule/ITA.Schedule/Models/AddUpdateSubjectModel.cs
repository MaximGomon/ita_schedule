using System.Collections.Generic;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.Models
{
    /// <summary>
    /// Model to be passed to the subjects list view
    /// </summary>
    public class AddUpdateSubjectModel
    {
        public Subject Subject { get; set; }
        public List<int> SubjectCodes { get; set; }
    }
}