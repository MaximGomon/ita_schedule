using System;
using System.Collections.Generic;
using ITA.Schedule.BLL.Implementations.Base;
using ITA.Schedule.BLL.Interface;
using ITA.Schedule.DAL.Repositories.Implementations;
using ITA.Schedule.DAL.Repositories.Interfaces;
using ITA.Schedule.Entity.Entities;
using NLog;

namespace ITA.Schedule.BLL.Implementations
{
    public class StudentBl : CrudBll<IStudentRepository, Student>, IStudentBl
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        public StudentBl(IStudentRepository repository) : base(repository)
        {
        }

        public IEnumerable<Student> GetAllByGroup(Guid groupId)
        {
            _logger.Info("GetAllByGroup ({0})", groupId);
            return Repository.Get(s => s.SubGroup.Group.Id == groupId);
        }

        public IEnumerable<Student> GetAllBySubGroup(Guid subGroupId)
        {
            _logger.Info("GetAllBySubGroup ({0})", subGroupId);
            return Repository.Get(s => s.SubGroup.Id == subGroupId);
        }

        public void ReplaceToAnotherSubGroup(Guid studentId, Guid newSubGroupId)
        {
            var student = Repository.GetById(studentId);
            if (student.SubGroup.Id == newSubGroupId)
            {
                return;
            }

            var newSubGroup = new SubGroupBl(new SubgroupRepository()).GetById(newSubGroupId);
            student.SubGroup = newSubGroup;
            _logger.Info("ReplaceToAnotherSubGroup ({0} , {1})", studentId, newSubGroupId);
        }

        public IEnumerable<Student> GetAllBySubGroup(string subGroupName)
        {
            _logger.Info("GetAllBySubGroup ({0})", subGroupName);
            return Repository.Get(s => s.SubGroup.Name == subGroupName);
        }

        public bool AddNewStudent(string name, Guid subgroupId)
        {
            var student = new Student();

            if (name.Trim() == String.Empty && name.Length > 400)
            {
                return false;
            }
            student.Name = name;

            var subgroup = Repository.AttachSubgroup(subgroupId);

            if (subgroup == null)
            {
                return false;
            }
            student.SubGroup = subgroup;

            _logger.Info("AddNewStudent ({0} , {1})", name, subgroupId);
            Repository.Add(student);

            return true;
        }

        // update teacher name and subjects
        public bool UpdateStudent(Guid studentId, string newName, Guid subgroupId)
        {
            // if something is wrong with new name
            if (newName == String.Empty || newName.Length > 400)
            {
                return false;
            }

            // looking for a studentId
            var student = GetById(studentId);

            // if we couldn't find a student
            if (student == null)
            {
                return false;
            }

            // change teacher's name
            if (!student.Name.Equals(newName))
            {
                student.Name = newName;
            }

            // if the subgroup ID is wrong
            var subgroup = Repository.AttachSubgroup(subgroupId);
            if (subgroup == null)
            {
                return false;
            }

            // change subgroup
            if (student.SubGroup == null || student.SubGroup.Id != subgroupId)
            {
                student.SubGroup = subgroup;
            }
            _logger.Info("UpdateStudent ({0} , {1}, {2})", studentId, newName, subgroupId);
            // update student
            Update(student);

            return true;
        }
    }
}
