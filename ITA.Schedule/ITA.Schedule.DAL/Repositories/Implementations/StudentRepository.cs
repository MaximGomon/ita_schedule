using System;
using System.Linq;
using ITA.Schedule.DAL.Repositories.Interfaces;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.DAL.Repositories.Implementations
{
    /// <summary>
    /// To perform CRUD operations over Student entity
    /// </summary>
    public class StudentRepository : CrudRepository<Student>, IStudentRepository
    {
        public SubGroup AttachSubgroup(Guid subgroupId)
        {
            return ContextDb.SubGroups.FirstOrDefault(x => x.Id == subgroupId);
        }
    }
}