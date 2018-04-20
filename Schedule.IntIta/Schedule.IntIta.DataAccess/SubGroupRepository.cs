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
        private readonly IntitaDbContext _context;
        public SubGroupRepository(IntitaDbContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            var deletableItem = _context.SubGroups.Find(id);
            deletableItem.IsDeleted = true;
            _context.SaveChanges();
        }

        public SubGroup Get(int id)
        {
            var subgroup = _context.SubGroups.Find(id);
            return subgroup;
        }

        public IEnumerable<SubGroup> GetAll()
        {
            IEnumerable<SubGroup> subgroupList = _context.SubGroups.ToList();
            return subgroupList;
        }

        public void Insert(SubGroup item)
        {
            _context.SubGroups.Add(item);
            _context.SaveChanges();
        }

        public void Update(SubGroup modifiedItem)
        {
            var oldSubGroup = _context.SubGroups.Find(modifiedItem.Id);
            oldSubGroup.GroupId = modifiedItem.GroupId;
            oldSubGroup.Name = modifiedItem.Name;
            oldSubGroup.NumberOfStudents = modifiedItem.NumberOfStudents;
            oldSubGroup.SubGroupTimeSlot = modifiedItem.SubGroupTimeSlot;
            _context.SaveChanges();
        }
    }
}
