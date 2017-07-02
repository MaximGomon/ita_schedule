using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ITA.Schedule.Util;
using ITA.Schedule.DAL.Repositories.Interfaces;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.DAL.Repositories.Implementations
{
    /// <summary>
    /// Repository to perform CRUD operations ofver Teacher entity
    /// </summary>
    public class TeacherRepository : CrudRepository<Teacher>, ITeacherRepository
    {
        /// <summary>Method to add particular subject from a teacher</summary>
        public void AddSubjectToTeacher(Guid teacherId, Guid subjecId)
        {
            var teacher = GetById(teacherId);
            teacher.Subjects.Add(ContextDb.Subjects.FirstOrDefault(x => x.Id == subjecId));
            Update(teacher);
        }

        /// <summary>Method to delete particular subject from a teacher</summary>
        public void DeleteSubjectFromTeacher(Guid teacherId, Guid subjecId)
        {
            var teacher = GetById(teacherId);
            teacher.Subjects.Remove(ContextDb.Subjects.FirstOrDefault(x => x.Id == subjecId));
            Update(teacher);
        }

        /// <summary>set teacher busy on a particular day</summary>
        public bool SetTeacherBusy(Guid teacherId, LessonTime lessonTime, DateTime day)
        {
            var teacher = GetById(teacherId);
            try
            {
                teacher.TeacherAllTimes.First(x => x.LessonTime == lessonTime 
                    && x.Date.IsDateEqualWithoutTime(day)).IsBusy = true;
                Update(teacher);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>set teacher free on a particular day</summary>
        public bool SetTeacherFree(Guid teacherId, LessonTime lessonTime, DateTime day)
        {
            var teacher = GetById(teacherId);
            try
            {
                teacher.TeacherAllTimes.First(x => x.LessonTime == lessonTime
                    && x.Date.IsDateEqualWithoutTime(day)).IsBusy = false;
                Update(teacher);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>set teacher active on a particular day</summary>
        public bool SetTeacherActive(Guid teacherId, LessonTime lessonTime, DateTime day)
        {
            var teacher = GetById(teacherId);
            try
            {
                teacher.TeacherAllTimes.First(x => x.LessonTime == lessonTime
                    && x.Date.IsDateEqualWithoutTime(day)).IsActive = true;
                Update(teacher);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>set teacher inactive on a particular day</summary>
        public bool SetTeacherInactive(Guid teacherId, LessonTime lessonTime, DateTime day)
        {
            var teacher = GetById(teacherId);
            try
            {
                teacher.TeacherAllTimes.First(x => x.LessonTime == lessonTime
                    && x.Date.IsDateEqualWithoutTime(day)).IsActive = false;
                Update(teacher);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>gets all teachers with subjects which they lead</summary>
        public override IQueryable<Teacher> GetAllEntities()
        {
            return ContextDb.Set<Teacher>().Include(x => x.Subjects);
        }

        /// <summary>gets all teachers with subjects which they lead</summary>
        public override Teacher GetById(Guid id)
        {
            return ContextDb.Set<Teacher>()
                .Where(x => x.Id == id)
                .Include(x => x.Subjects)
                .FirstOrDefault();
        }
    }
}