using System;
using System.Collections.Generic;
using System.Linq;
using ITA.Schedule.DAL.Repositories.Interfaces;
using ITA.Schedule.Entity.Entities;
using ITA.Schedule.Util;

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

        //Get lessons for student by filter
        public IEnumerable<ScheduleLesson> GetStudentScheduleLessonsByFilter(Guid subgroupId, DateTime date, Guid teacherId, Guid subjectId, TimePeriod period)
        {
            if (teacherId == Guid.Empty)
            {
                switch (period)
                {

                 case TimePeriod.Day:
                        return ContextDb.ScheduleLessons.Where(x=>x.SubGroups.Any(y=>y.Id == subgroupId) && x.Subject.Id == subjectId && 
                        x.LessonDate.IsDateEqualWithoutTime(date) && x.IsDeleted == false).ToList();
                        
                 case TimePeriod.Week:
                        DateTime monday = date.AddDays(-1 * (int)(date.DayOfWeek) + 1);
                        DateTime sunday = date.AddDays(6); 

                        return ContextDb.ScheduleLessons.Where(x => x.SubGroups.Any(y => y.Id == subgroupId) && x.Subject.Id == subjectId && 
                                x.LessonDate.Date >= monday.Date &&
                                x.LessonDate.Date <= sunday.Date).ToList();
                        
                 case TimePeriod.Month:
                        DateTime monthMonday = date.MondayOfConcreteMonth();
                        DateTime monthSunday = date.LastSundayOfConcreteMonth();

                        return ContextDb.ScheduleLessons.Where(x => x.SubGroups.Any(y => y.Id == subgroupId) && x.Subject.Id == subjectId &&
                                                                    x.LessonDate.Date >= monthMonday.Date &&
                                                                    x.LessonDate.Date.Date <= monthSunday.Date).ToList(); 
                }
            }
            if (subjectId == Guid.Empty)
            {
                switch (period)
                {

                    case TimePeriod.Day:
                        return ContextDb.ScheduleLessons.Where(x => x.SubGroups.Any(y => y.Id == subgroupId) && x.Teacher.Id == teacherId &&
                        x.LessonDate.IsDateEqualWithoutTime(date) && x.IsDeleted == false).ToList();

                    case TimePeriod.Week:
                        DateTime monday = date.AddDays(-1 * (int)(date.DayOfWeek) + 1);
                        DateTime sunday = date.AddDays(6);

                        return ContextDb.ScheduleLessons.Where(x => x.SubGroups.Any(y => y.Id == subgroupId) && x.Teacher.Id == teacherId &&
                                x.LessonDate.Date >= monday.Date &&
                                x.LessonDate.Date <= sunday.Date).ToList();

                    case TimePeriod.Month:
                        DateTime monthMonday = date.MondayOfConcreteMonth();
                        DateTime monthSunday = date.LastSundayOfConcreteMonth();

                        return ContextDb.ScheduleLessons.Where(x => x.SubGroups.Any(y => y.Id == subgroupId) && x.Teacher.Id == teacherId &&
                                                                    x.LessonDate.Date >= monthMonday.Date &&
                                                                    x.LessonDate.Date.Date <= monthSunday.Date).ToList();
                }
            }
            if (teacherId == Guid.Empty && subjectId == Guid.Empty)
            {
                switch (period)
                {

                    case TimePeriod.Day:
                        return ContextDb.ScheduleLessons.Where(x => x.SubGroups.Any(y => y.Id == subgroupId) &&
                                                                    x.LessonDate.IsDateEqualWithoutTime(date) &&
                                                                    x.IsDeleted == false).ToList();

                    case TimePeriod.Week:
                        DateTime monday = date.AddDays(-1*(int) (date.DayOfWeek) + 1);
                        DateTime sunday = date.AddDays(6);

                        return ContextDb.ScheduleLessons.Where(x => x.SubGroups.Any(y => y.Id == subgroupId) &&
                                                                    x.LessonDate.Date >= monday.Date &&
                                                                    x.LessonDate.Date <= sunday.Date).ToList();

                    case TimePeriod.Month:
                        DateTime monthMonday = date.MondayOfConcreteMonth();
                        DateTime monthSunday = date.LastSundayOfConcreteMonth();

                        return ContextDb.ScheduleLessons.Where(x => x.SubGroups.Any(y => y.Id == subgroupId) &&
                                                                    x.LessonDate.Date >= monthMonday.Date &&
                                                                    x.LessonDate.Date.Date <= monthSunday.Date).ToList();
                }
            }

            else
            {
                switch (period)
                {

                    case TimePeriod.Day:
                        return ContextDb.ScheduleLessons.Where(x => x.SubGroups.Any(y => y.Id == subgroupId) && 
                                x.Teacher.Id == teacherId && x.Subject.Id == subjectId &&
                                x.LessonDate.IsDateEqualWithoutTime(date) && x.IsDeleted == false).ToList();

                    case TimePeriod.Week:
                        DateTime monday = date.AddDays(-1 * (int)(date.DayOfWeek) + 1);
                        DateTime sunday = date.AddDays(6);

                        return ContextDb.ScheduleLessons.Where(x => x.SubGroups.Any(y => y.Id == subgroupId) && 
                                x.Teacher.Id == teacherId && x.Subject.Id == subjectId &&
                                x.LessonDate.Date >= monday.Date &&
                                x.LessonDate.Date <= sunday.Date).ToList();

                    case TimePeriod.Month:
                        DateTime monthMonday = date.MondayOfConcreteMonth();
                        DateTime monthSunday = date.LastSundayOfConcreteMonth();

                        return ContextDb.ScheduleLessons.Where(x => x.SubGroups.Any(y => y.Id == subgroupId) && 
                                x.Teacher.Id == teacherId && x.Subject.Id == subjectId &&
                                x.LessonDate.Date >= monthMonday.Date &&
                                x.LessonDate.Date.Date <= monthSunday.Date).ToList();
                }
            }
            return null;
        }

        public IEnumerable<ScheduleLesson> GetTeacherScheduleLessonsByFilter(Guid teacherId, DateTime date, Guid groupId, Guid subgroupId, TimePeriod period)
        {
            if (groupId == Guid.Empty)
            {
                switch (period)
                {

                    case TimePeriod.Day:
                        return ContextDb.ScheduleLessons.Where(x => x.Teacher.Id == teacherId &&
                        x.LessonDate.IsDateEqualWithoutTime(date) && x.IsDeleted == false).ToList();

                    case TimePeriod.Week:
                        DateTime monday = date.AddDays(-1 * (int)(date.DayOfWeek) + 1);
                        DateTime sunday = date.AddDays(6);

                        return ContextDb.ScheduleLessons.Where(x => x.Teacher.Id == teacherId &&
                                x.LessonDate.Date >= monday.Date &&
                                x.LessonDate.Date <= sunday.Date).ToList();

                    case TimePeriod.Month:
                        DateTime monthMonday = date.MondayOfConcreteMonth();
                        DateTime monthSunday = date.LastSundayOfConcreteMonth();

                        return ContextDb.ScheduleLessons.Where(x => x.Teacher.Id == teacherId &&
                                                                    x.LessonDate.Date >= monthMonday.Date &&
                                                                    x.LessonDate.Date.Date <= monthSunday.Date).ToList();
                }
            }
            if (subgroupId == Guid.Empty)
            {
                switch (period)
                {

                    case TimePeriod.Day:
                        return ContextDb.ScheduleLessons.Where(x => x.SubGroups.Any(y => y.Group.Id == groupId) && x.Teacher.Id == teacherId &&
                        x.LessonDate.IsDateEqualWithoutTime(date) && x.IsDeleted == false).ToList();

                    case TimePeriod.Week:
                        DateTime monday = date.AddDays(-1 * (int)(date.DayOfWeek) + 1);
                        DateTime sunday = date.AddDays(6);

                        return ContextDb.ScheduleLessons.Where(x => x.SubGroups.Any(y => y.Id == subgroupId) && x.Teacher.Id == teacherId &&
                                x.LessonDate.Date >= monday.Date &&
                                x.LessonDate.Date <= sunday.Date).ToList();

                    case TimePeriod.Month:
                        DateTime monthMonday = date.MondayOfConcreteMonth();
                        DateTime monthSunday = date.LastSundayOfConcreteMonth();

                        return ContextDb.ScheduleLessons.Where(x => x.SubGroups.Any(y => y.Id == subgroupId) && x.Teacher.Id == teacherId &&
                                                                    x.LessonDate.Date >= monthMonday.Date &&
                                                                    x.LessonDate.Date.Date <= monthSunday.Date).ToList();
                }
            }
            //if (teacherId == Guid.Empty && subjectId == Guid.Empty)
            //{
            //    switch (period)
            //    {

            //        case TimePeriod.Day:
            //            return ContextDb.ScheduleLessons.Where(x => x.SubGroups.Any(y => y.Id == subgroupId) &&
            //                                                        x.LessonDate.IsDateEqualWithoutTime(date) &&
            //                                                        x.IsDeleted == false).ToList();

            //        case TimePeriod.Week:
            //            DateTime monday = date.AddDays(-1 * (int)(date.DayOfWeek) + 1);
            //            DateTime sunday = date.AddDays(6);

            //            return ContextDb.ScheduleLessons.Where(x => x.SubGroups.Any(y => y.Id == subgroupId) &&
            //                                                        x.LessonDate.Date >= monday.Date &&
            //                                                        x.LessonDate.Date <= sunday.Date).ToList();

            //        case TimePeriod.Month:
            //            DateTime monthMonday = date.MondayOfConcreteMonth();
            //            DateTime monthSunday = date.LastSundayOfConcreteMonth();

            //            return ContextDb.ScheduleLessons.Where(x => x.SubGroups.Any(y => y.Id == subgroupId) &&
            //                                                        x.LessonDate.Date >= monthMonday.Date &&
            //                                                        x.LessonDate.Date.Date <= monthSunday.Date).ToList();
            //    }
            //}

            //else
            //{
            //    switch (period)
            //    {

            //        case TimePeriod.Day:
            //            return ContextDb.ScheduleLessons.Where(x => x.SubGroups.Any(y => y.Id == subgroupId) &&
            //                    x.Teacher.Id == teacherId && x.Subject.Id == subjectId &&
            //                    x.LessonDate.IsDateEqualWithoutTime(date) && x.IsDeleted == false).ToList();

            //        case TimePeriod.Week:
            //            DateTime monday = date.AddDays(-1 * (int)(date.DayOfWeek) + 1);
            //            DateTime sunday = date.AddDays(6);

            //            return ContextDb.ScheduleLessons.Where(x => x.SubGroups.Any(y => y.Id == subgroupId) &&
            //                    x.Teacher.Id == teacherId && x.Subject.Id == subjectId &&
            //                    x.LessonDate.Date >= monday.Date &&
            //                    x.LessonDate.Date <= sunday.Date).ToList();

            //        case TimePeriod.Month:
            //            DateTime monthMonday = date.MondayOfConcreteMonth();
            //            DateTime monthSunday = date.LastSundayOfConcreteMonth();

            //            return ContextDb.ScheduleLessons.Where(x => x.SubGroups.Any(y => y.Id == subgroupId) &&
            //                    x.Teacher.Id == teacherId && x.Subject.Id == subjectId &&
            //                    x.LessonDate.Date >= monthMonday.Date &&
            //                    x.LessonDate.Date.Date <= monthSunday.Date).ToList();
            //    }
            //}
            return null;
        }

        public ScheduleLessonRepository(ScheduleDbContext context) : base(context)
        {
        }
    }
}