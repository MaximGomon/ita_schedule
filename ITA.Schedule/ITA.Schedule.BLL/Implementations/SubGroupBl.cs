using System;
using ITA.Schedule.BLL.Implementations.Base;
using ITA.Schedule.BLL.Interface;
using ITA.Schedule.DAL.Repositories.Interfaces;
using ITA.Schedule.Entity.Entities;
using NLog;

namespace ITA.Schedule.BLL.Implementations
{
    public class SubGroupBl : CrudBll<ISubgroupRepository, SubGroup>, ISubGroupBl
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        public SubGroupBl(ISubgroupRepository repository) : base(repository)
        {
        }

        public void AddStudentToSubgroup(Guid subgroupId, Guid studentId)
        {
            Repository.AddStudentToSubgroup(subgroupId, studentId);
            _logger.Info("AddStudentToSubgroup ({0} , {1})", subgroupId, studentId);
        }

        public void RemoveStudentFromSubgroup(Guid subgroupId, Guid studentId)
        {
            Repository.RemoveStudentFromSubgroup(subgroupId, studentId);
            _logger.Info("RemoveStudentFromSubgroup ({0} , {1})", subgroupId, studentId);
        }
    }
}
