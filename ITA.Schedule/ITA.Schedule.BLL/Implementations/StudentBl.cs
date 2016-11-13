using System;
using System.Collections.Generic;
using ITA.Schedule.BLL.Implementations.Base;
using ITA.Schedule.BLL.Interface;
using ITA.Schedule.DAL.Repositories.Interfaces;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.BLL.Implementations
{
    public class StudentBl : CrudBll<IStudentRepository, Student>, IStudentBl
    {
        public StudentBl(IStudentRepository repository) : base(repository)
        {
        }

        public IEnumerable<Student> GetAllByGroup(Guid groupId)
        {
            return Repository.Get(s => s.SubGroup.Group.Id == groupId);
        }

        public IEnumerable<Student> GetAllBySubGroup(Guid subGroupId)
        {
            return Repository.Get(s => s.SubGroup.Id == subGroupId);
        }

        public void ReplaceToAnotherSubGroup(Guid studentId, Guid newSubGroupId)
        {
            var studentSubGroupId = Repository.GetById(studentId).SubGroup.Id;
            if (studentSubGroupId == newSubGroupId)
            {
                return;
            }


        }
        
    }
}
