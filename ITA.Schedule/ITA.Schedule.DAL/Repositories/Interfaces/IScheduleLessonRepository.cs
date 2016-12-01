using System;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.DAL.Repositories.Interfaces
{
    /// <summary>
    /// Interface to be implemented by ScheduleLessonRepository
    /// </summary>
    public interface IScheduleLessonRepository : ICrudRepository<ScheduleLesson>
    {
        // check if a teacher has scheduled lessons
        bool IsWithScheduledLessons(Guid teacherId);
    }
}