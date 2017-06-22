using System;
using System.Collections.Generic;
using System.Linq;
using ITA.Schedule.BLL.Implementations.Base;
using ITA.Schedule.BLL.Interface;
using ITA.Schedule.DAL.Repositories.Interfaces;
using ITA.Schedule.Entity.Entities;
using NLog;

namespace ITA.Schedule.BLL.Implementations
{
    public class SubjectBl : CrudBll<ISubjectRepository, Subject>, ISubjectBl
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        public SubjectBl(ISubjectRepository repository) : base(repository)
        {
        }

        ////get all entities from db by type
        //public new ICollection<Subject> GetAll()
        //{
        //    return Repository.GetAllEntities().ToList();
        //}

        // update subject method
        public bool UpdateSubject(Guid subjectId, string newSubjectName, int newCode)
        {
            // if something is wrong with new name
            if (newSubjectName == String.Empty || newSubjectName.Length > 400 || newCode <= 0)
            {
                return false;
            }

            // looking for a subject
            var subject = GetById(subjectId);

            // if we couldn't find a subject
            if (subject == null)
            {
                return false;
            }

            // change subject code
            if (subject.Code != newCode)
            {
                subject.Code = newCode;
            }

            // change name of the subject
            if (!subject.Name.Equals(newSubjectName))
            {
                subject.Name = newSubjectName;
            }
            _logger.Info("UpdateSubject ({0} , {1} , {2})", subjectId, newSubjectName, newCode);
            Update(subject);
            return true;
        }
    }
}
