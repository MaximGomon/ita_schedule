using System;
using System.Collections.Generic;
using ITA.Schedule.Entity.Entities;
using ITA.Schedule.Util;

namespace ITA.Schedule.DAL.Repositories.Interfaces
{
    /// <summary>
    /// Interface to be implemented by ScheduleLessonRepository
    /// </summary>
    public interface IScheduleLessonRepository : ICrudRepository<ScheduleLesson>
    {
        /// <summary>check if a teacher has scheduled lessons</summary>
        bool IsWithScheduledLessons(Guid teacherId);

        IEnumerable<ScheduleLesson> GetStudentScheduleLessonsByFilter(Guid subgroupId, DateTime date, Guid teacherId,
            Guid subjectId, TimePeriod period);

        IEnumerable<ScheduleLesson> GetTeacherScheduleLessonsByFilter(Guid teacherId, DateTime date, Guid groupId,
            Guid subgroupId, TimePeriod period);

    }
}