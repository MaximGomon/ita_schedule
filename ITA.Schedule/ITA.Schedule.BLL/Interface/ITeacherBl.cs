using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ITA.Schedule.BLL.Interface.Base;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.BLL.Interface
{
    interface ITeacherBl : ICrudBl<Teacher>
    {
        /// <summary>adding a subject to a teacher</summary>
        void AddSubjectToTeacher(Guid teacherId, Guid subjecId);

        /// <summary>delete subject from a teacher</summary>
        void DeleteSubjectFromTeacher(Guid teacherId, Guid subjecId);

        /// <summary>set teacher busy on a particular day</summary>
        bool SetTeacherBusy(Guid teacherId, LessonTime lessonTime, DateTime day);

        /// <summary>set teacher free on a particular day</summary>
        bool SetTeacherFree(Guid teacherId, LessonTime lessonTime, DateTime day);

        /// <summary>set teacher active on a particular day</summary>
        bool SetTeacherActive(Guid teacherId, LessonTime lessonTime, DateTime day);

        /// <summary>set teacher inactive on a particular day</summary>
        bool SetTeacherInactive(Guid teacherId, LessonTime lessonTime, DateTime day);
        
        IEnumerable<Teacher> GetFreeTeacherOnDate(DateTime date);

        //IEnumerable<Teacher> GetAllTeachers();
        //Teacher Get(Expression<Func<Teacher, bool>> predicate);
        // update teacher subjects and free time

        bool UpdateTeacher(Guid teacherId, string newName, List<Guid> subjectsIds);
    }
}
