using System;
using ITA.Schedule.BLL.Implementations.Base;
using ITA.Schedule.BLL.Interface;
using ITA.Schedule.DAL.Repositories.Interfaces;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.BLL.Implementations
{
    /// <summary>
    /// Logic to work with Scheduled Lessons
    /// </summary>
    public class ScheduleLessonBl : CrudBll<IScheduleLessonRepository, ScheduleLesson>, IScheduleLessonBl
    {
        public ScheduleLessonBl(IScheduleLessonRepository repository) : base(repository)
        {
        }

        // to check if a user has schediled lessons
        public bool IsWithScheduledLessons(Guid teacherId)
        {
            return Repository.IsWithScheduledLessons(teacherId);
        }
    }
}