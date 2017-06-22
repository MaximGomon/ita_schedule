using System;
using System.Collections.Generic;
using System.Linq;
using ITA.Schedule.BLL.Implementations.Base;
using ITA.Schedule.BLL.Interface;
using ITA.Schedule.DAL.Repositories.Interfaces;
using ITA.Schedule.Entity.Entities;
using ITA.Schedule.Util;
using NLog;


namespace ITA.Schedule.BLL.Implementations
{
    public class TeacherBl : CrudBll<ITeacherRepository, Teacher>, ITeacherBl
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        public TeacherBl(ITeacherRepository repository) : base(repository)
        {

        }

        public void AddSubjectToTeacher(Guid teacherId, Guid subjecId)
        {
            Repository.AddSubjectToTeacher(teacherId, subjecId);
            _logger.Info("AddSubjectToTeacher ({0} , {1})", teacherId, subjecId);
        }

        public void DeleteSubjectFromTeacher(Guid teacherId, Guid subjecId)
        {
            Repository.DeleteSubjectFromTeacher(teacherId, subjecId);
            _logger.Info("DeleteSubjectFromTeacher ({0} , {1})", teacherId, subjecId);
        }

        public bool SetTeacherBusy(Guid teacherId, LessonTime lessonTime, DateTime day)
        {
            _logger.Info("SetTeacherBusy ({0} , {1} , {2})", teacherId, lessonTime, day);
            return Repository.SetTeacherBusy(teacherId, lessonTime, day);

        }

        public bool SetTeacherFree(Guid teacherId, LessonTime lessonTime, DateTime day)
        {
            _logger.Info("SetTeacherFree ({0} , {1} , {2})", teacherId, lessonTime, day);
            return Repository.SetTeacherFree(teacherId, lessonTime, day);
        }

        public bool SetTeacherActive(Guid teacherId, LessonTime lessonTime, DateTime day)
        {
            _logger.Info("SetTeacherActive ({0} , {1} , {2})", teacherId, lessonTime, day);
            return Repository.SetTeacherActive(teacherId, lessonTime, day);
        }

        public bool SetTeacherInactive(Guid teacherId, LessonTime lessonTime, DateTime day)
        {
            _logger.Info("SetTeacherInactive ({0} , {1} , {2})", teacherId, lessonTime, day);
            return Repository.SetTeacherInactive(teacherId, lessonTime, day);
        }

        public IEnumerable<Teacher> GetFreeTeacherOnDate(DateTime date)
        {
            var allTeachers = Repository.GetAllEntities();
            var teachersFree = new List<Teacher>();

            foreach (var teacher in allTeachers)
            {
                if (teacher.TeacherAllTimes.Any(t => t.IsActive && !t.IsBusy &&
                    (t.Date.IsDateEqualWithoutTime(date))))
                {
                    teachersFree.Add(teacher);
                }
            }
            _logger.Info("GetFreeTeacherOnDate ({0})", date);
            return teachersFree;
        }

        // update teacher name and subjects
        public bool UpdateTeacher(Guid teacherId, string newName, List<Guid> subjectsIds)
        {
            _logger.Info("UpdateTeacher ({0} , {1} , {2})", teacherId, newName, subjectsIds);
            // if something is wrong with new name
            if (newName == String.Empty || newName.Length > 400)
            {
                return false;
            }

            // looking for a teacher
            var teacher = GetById(teacherId);

            // if we couldn't find a teacher
            if (teacher == null)
            {
                return false;
            }

            // change teacher's name
            if (!teacher.Name.Equals(newName))
            {
                teacher.Name = newName;
                Update(teacher);
            }

            // list of subjects to be removed
            var subjectsToRemoveIds = new List<Guid>();

            // if we don't update subjects
            if (subjectsIds != null)
            {
                // determine which subjects are to be removed from and added to a teacher
                foreach (var subject in teacher.Subjects)
                {
                    // if there is no such subject in the Ids list, it should be removed
                    if (!subjectsIds.Exists(x => x.Equals(subject.Id)))
                    {
                        subjectsToRemoveIds.Add(subject.Id);
                    }
                    // else - remove subject from Ids list
                    else
                    {
                        subjectsIds.Remove(subject.Id);
                    }
                }

                // add subjects to a teacher
                foreach (var subjectsId in subjectsIds)
                {
                    AddSubjectToTeacher(teacherId, subjectsId);
                }
            }
            else
            {
                subjectsToRemoveIds.AddRange(teacher.Subjects.Select(subject => subject.Id));
            }

            // delete subjects which a teacher will not be leading any more
            foreach (var subjectsToRemoveId in subjectsToRemoveIds)
            {
                DeleteSubjectFromTeacher(teacherId, subjectsToRemoveId);
            }
            
            return true;
        }
    }
}
