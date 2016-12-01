using System;
using System.Linq;
using ITA.Schedule.DAL.Repositories.Interfaces;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.DAL.Repositories.Implementations
{
    /// <summary>
    /// Repository to schedule lessons
    /// </summary>
    public class ScheduleLessonRepository : CrudRepository<ScheduleLesson>, IScheduleLessonRepository
    {
        // check if a teacher has scheduled lessons
        public bool IsWithScheduledLessons(Guid teacherId)
        {
            return ContextDb.Set<ScheduleLesson>().Any(x => x.Teacher.Id == teacherId);
        }
    }
}