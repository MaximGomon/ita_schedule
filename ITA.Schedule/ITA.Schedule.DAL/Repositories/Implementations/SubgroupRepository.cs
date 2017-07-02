using System;
using System.Linq;
using ITA.Schedule.DAL.Repositories.Interfaces;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.DAL.Repositories.Implementations
{
    /// <summary>
    /// To perform CRUD operations over Subgroup entity
    /// </summary>
    public class SubgroupRepository : CrudRepository<SubGroup>, ISubgroupRepository
    {
        /// <summary>add a student to a subgroup</summary>
        public void AddStudentToSubgroup(Guid subgroupId, Guid studentId)
        {
            var subgroup = GetById(subgroupId);
            subgroup.Students.Add(ContextDb.Students.FirstOrDefault(x => x.Id == studentId));
            Update(subgroup);
        }

        /// <summary>remove a student from a subgroup</summary>
        public void RemoveStudentFromSubgroup(Guid subgroupId, Guid studentId)
        {
            var subgroup = GetById(subgroupId);
            subgroup.Students.Remove(ContextDb.Students.FirstOrDefault(x => x.Id == studentId));
            Update(subgroup);
        }
    }
}