using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using ITA.Schedule.DAL.Repositories.Interfaces;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.DAL.Repositories.Implementations
{
    /// <summary>
    /// To perform CRUD operations over Group entity
    /// </summary>
    public class GroupRepository : CrudRepository<Group>, IGroupRepository
    {
        // add a subgroup to a group
        public void AddSubgroupToGroup(Guid groupId, Guid subgroupId)
        {
            var group = GetById(groupId);
            group.SubGroups.Add(ContextDb.SubGroups.FirstOrDefault(x => x.Id == subgroupId));
            Update(group);
        }

        // remove a subgroup from a group
        public void UnlinkSubgroupFromGroup(Guid groupId, Guid subgroupId)
        {
            var group = GetById(groupId);
            group.SubGroups.Remove(ContextDb.SubGroups.FirstOrDefault(x => x.Id == subgroupId));
            Update(group);
        }

        /*public override IQueryable<Group> Get(Expression<Func<Group, bool>> predicate)
        {
            return base.Get(predicate)
                .Include(x => x.SubGroups);
        }*/

        public GroupRepository(ScheduleDbContext context) : base(context)
        {
        }
    }
}