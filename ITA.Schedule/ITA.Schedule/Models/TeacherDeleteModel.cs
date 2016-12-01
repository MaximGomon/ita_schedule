using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.Models
{
    /// <summary>
    /// Model is used to delete teacher confirmation
    /// </summary>
    public class TeacherDeleteModel
    {
        // if true - teacher has scheduled lessons and he couldn't be deleted
        public bool IsWithScheduledLessons { get; set; }
        // if true - teacher has a user and cannot be deleted
        public bool IsWithUser { get; set; }
        // teacher entity to be deleted
        public Teacher Teacher { get; set; }
    }
}