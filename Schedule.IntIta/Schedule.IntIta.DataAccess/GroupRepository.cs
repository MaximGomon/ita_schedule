using System.Collections.Generic;
using Schedule.IntIta.Domain.Models;
using System;
using Schedule.IntIta.DataAccess.Context;
using System.Linq;

namespace Schedule.IntIta.DataAccess
{
    public class GroupRepository : IGroupRepository
    {
        private readonly IntitaDbContext _context;
        public GroupRepository(IntitaDbContext context)
        {
            _context = context;
        }

        public void Insert(Group item)
        {
            _context.Groups.Add(item);
            _context.SaveChanges();
        }
        public Group Get(int id)
        {
            var group = _context.Groups.Find(id);
            return group;
        }
        public void Update(Group modifiedItem)
        {
            var oldGroup = _context.Groups.Find(modifiedItem.Id);
            oldGroup.Name = modifiedItem.Name;
            oldGroup.NumberOfStudents = modifiedItem.NumberOfStudents;
            oldGroup.Subgroups = modifiedItem.Subgroups;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var deletableItem = _context.Groups.Find(id);
            deletableItem.IsDeleted = true;
            _context.SaveChanges();
        }

        public IEnumerable<Group> GetAll()
        {
            IEnumerable<Group> groupList = _context.Groups.ToList();
            return groupList;
        }
    }
}

