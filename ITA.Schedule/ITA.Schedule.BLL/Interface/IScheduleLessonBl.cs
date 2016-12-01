using System;

namespace ITA.Schedule.BLL.Interface
{
    /// <summary>
    /// To be implemented by ScheduleLessonBl
    /// </summary>
    public interface IScheduleLessonBl
    {
        // check if a teacher has scheduled lessons
        bool IsWithScheduledLessons(Guid teacherId);
    }
}