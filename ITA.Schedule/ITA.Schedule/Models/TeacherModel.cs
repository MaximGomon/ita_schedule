using System.Collections.Generic;

namespace ITA.Schedule.Models
{
    /// <summary>
    /// Model to display in teachers table of the admin view
    /// </summary>
    public class TeacherModel
    {
        // Teacher name
        public string Name;
        // Teacher subjects
        public List<string> Subjects;
    }
}