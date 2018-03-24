using System;
using System.Collections.Generic;
using System.Text;
using Schedule.IntIta.Domain.Models;
using Schedule.IntIta.DataAccess.Context;
using System.Linq;

namespace Schedule.IntIta.DataAccess
{
    public class SubGroupRepository : ISubGroupRepository
    {
        public void Delete(int id)
        {
            using (var context = new IntitaDbContext())
            {
                var deletableItem = context.SubGroups.Find(id);
                deletableItem.IsDeleted = true;
                context.SaveChanges();

            }

        }

        public SubGroup Get(int id)
        {
            using (var context = new IntitaDbContext())
            {
                var subgroup = context.SubGroups.Find(id);
                return subgroup;
            }

        }

        public IEnumerable<SubGroup> GetAll()
        {
            using (var context = new IntitaDbContext())
            {
                IEnumerable<SubGroup> subgroupList = context.SubGroups.ToList();
                return subgroupList;
            }

        }

        public void Insert(SubGroup item)
        {
            using (var context = new IntitaDbContext())
            {
                context.SubGroups.Add(item);
                context.SaveChanges();
            }

        }

        public void Update(SubGroup modifiedItem)
        {
            using (var context = new IntitaDbContext())
            {
                var oldSubGroup = context.SubGroups.Find(modifiedItem.Id);
                oldSubGroup.GroupId = modifiedItem.GroupId;
                oldSubGroup.Name = modifiedItem.Name;
                oldSubGroup.NumberOfStudents = modifiedItem.NumberOfStudents;
                oldSubGroup.SubGroupTimeSlot = modifiedItem.SubGroupTimeSlot;
                context.SaveChanges();
            }

        }
    }
}
