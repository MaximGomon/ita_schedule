using System.Collections.Generic;
using Schedule.IntIta.Domain.Models;
using System;
using Schedule.IntIta.DataAccess.Context;
using System.Linq;

namespace Schedule.IntIta.DataAccess
{
    public class GroupRepository : IGroupRepository
    {

        public void Insert(Group item)
        {
            using (var context = new IntitaDbContext())
            {
                context.Groups.Add(item);
                context.SaveChanges();
            }
        }
        public Group Get(int id)
        {
            using (var context = new IntitaDbContext())
            {
                var group = context.Groups.Find(id);
                return group;
            }
        }
        public void Update(Group modifiedItem)
        {
            using (var context = new IntitaDbContext())
            {
                var oldGroup = context.Groups.Find(modifiedItem.Id);
                oldGroup.Name = modifiedItem.Name;
                oldGroup.NumberOfStudents = modifiedItem.NumberOfStudents;
                oldGroup.Subgroups = modifiedItem.Subgroups;
                context.SaveChanges();
            }

        }

        public void Delete(int id)
        {
            using (var context = new IntitaDbContext())
            {
                var deletableItem = context.Groups.Find(id);
                deletableItem.IsDeleted = true;
                context.SaveChanges();

            }

        }

        public IEnumerable<Group> GetAll()
        {
            using (var context = new IntitaDbContext())
            {
                IEnumerable<Group> groupList = context.Groups.ToList();
                return groupList;
            }

        }
    }
}

