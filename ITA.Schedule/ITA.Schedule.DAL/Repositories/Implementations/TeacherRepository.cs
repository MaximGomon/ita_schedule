using System;
using System.Linq;
using ITA.Schedule.DAL.Repositories.Interfaces;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.DAL.Repositories.Implementations
{
    /// <summary>
    /// Repository to perform CRUD operations ofver Teacher entity
    /// </summary>
    public class TeacherRepository : CrudRepository<Teacher>, ITeacherRepository
    {
        // Method to add particular subject from a teacher
        public void AddSubjectToTeacher(Guid teacherId, Guid subjecId)
        {
            var teacher = GetById(teacherId);
            teacher.Subjects.Add(ContextDb.Subjects.FirstOrDefault(x => x.Id == subjecId));
            Update(teacher);
        }

        // Method to delete particular subject from a teacher
        public void DeleteSubjectFromTeacher(Guid teacherId, Guid subjecId)
        {
            var teacher = GetById(teacherId);
            teacher.Subjects.Remove(ContextDb.Subjects.FirstOrDefault(x => x.Id == subjecId));
            Update(teacher);
        }

        // set teacher busy on a particular day
        //todo test this method more thoroughly
        public void SetTeacherBusy(Guid teacherId, LessonTime lessonTime, DayInWeek day)
        {
            var teacher = GetById(teacherId);
            teacher.TeacherAllTimes.FirstOrDefault(x => x.LessonTime == lessonTime && x.Day == day).IsBusy = true;
            Update(teacher);
        }

        // set teacher free on a particular day
        //todo test this method more thoroughly
        public void SetTeacherFree(Guid teacherId, LessonTime lessonTime, DayInWeek day)
        {
            var teacher = GetById(teacherId);
            teacher.TeacherAllTimes.FirstOrDefault(x => x.LessonTime == lessonTime && x.Day == day).IsBusy = false;
            Update(teacher);
        }

        // set teacher active on a particular day
        //todo test this method more thoroughly
        public void SetTeacherActive(Guid teacherId, LessonTime lessonTime, DayInWeek day)
        {
            var teacher = GetById(teacherId);
            teacher.TeacherAllTimes.FirstOrDefault(x => x.LessonTime == lessonTime && x.Day == day).IsActive = true;
            Update(teacher);
        }

        // set teacher inactive on a particular day
        //todo test this method more thoroughly
        public void SetTeacherInactive(Guid teacherId, LessonTime lessonTime, DayInWeek day)
        {
            var teacher = GetById(teacherId);
            teacher.TeacherAllTimes.FirstOrDefault(x => x.LessonTime == lessonTime && x.Day == day).IsActive = false;
            Update(teacher);
        }
    }
}