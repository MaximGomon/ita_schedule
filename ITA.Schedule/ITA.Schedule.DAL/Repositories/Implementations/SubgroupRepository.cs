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
        // add a student to a subgroup
        public void AddStudentToSubgroup(Guid subgroupId, Guid studentId)
        {
            var subgroup = GetById(subgroupId);
            subgroup.Students.Add(ContextDb.Students.FirstOrDefault(x => x.Id == studentId));
            Update(subgroup);
        }

        // remove a student from a subgroup
        public void RemoveStudentFromSubgroup(Guid subgroupId, Guid studentId)
        {
            var subgroup = GetById(subgroupId);
            subgroup.Students.Remove(ContextDb.Students.FirstOrDefault(x => x.Id == studentId));
            Update(subgroup);
        }

        public SubgroupRepository(ScheduleDbContext context) : base(context)
        {
        }
    }
}