using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ITA.Schedule.BLL.Interface.Base;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.BLL.Interface
{
    interface ITeacherBl : ICrudBl<Teacher>
    {

        // adding a subject to a teacher
        void AddSubjectToTeacher(Guid teacherId, Guid subjecId);
        // delete subject from a teacher
        void DeleteSubjectFromTeacher(Guid teacherId, Guid subjecId);
        // set teacher busy on a particular day
        bool SetTeacherBusy(Guid teacherId, LessonTime lessonTime, DateTime day);
        // set teacher free on a particular day
        bool SetTeacherFree(Guid teacherId, LessonTime lessonTime, DateTime day);
        // set teacher active on a particular day
        bool SetTeacherActive(Guid teacherId, LessonTime lessonTime, DateTime day);
        // set teacher inactive on a particular day
        bool SetTeacherInactive(Guid teacherId, LessonTime lessonTime, DateTime day);
        IEnumerable<Teacher> GetFreeTeacherOnDate(DateTime date);
        //IEnumerable<Teacher> GetAllTeachers();
        //Teacher Get(Expression<Func<Teacher, bool>> predicate);
        // update teacher subjects and free time
        bool UpdateTeacher(Guid teacherId, string newName, List<Guid> subjectsIds);
    }
}
