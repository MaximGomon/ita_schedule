using System;
using System.Collections.Generic;
using System.Linq;
using Schedule.IntIta.DataAccess.Context;
using Schedule.IntIta.Domain.Models;

namespace Schedule.IntIta.DataAccess
{
    public class OfficeRepository : IOfficeRepository
    {
        private readonly IntitaDbContext _context;

        public OfficeRepository(IntitaDbContext context)
        {
            _context = context;
        }

        public void Insert(Office item)
        {
            _context.Office.Add(item);
            _context.SaveChanges();
        }

        public Office Get(int id)
        {
            var office = _context.Office
                .Single(s => s.Id == id);
            return office;
        }

        public void Delete(int id)
        {
            var office = _context.Office
                .Single(s => s.Id == id);
            office.IsDeleted = true;
            _context.SaveChanges();
        }

        public void Update(Office modifiedItem)
        {
            _context.Office.Update(modifiedItem);
            _context.SaveChanges();
        }

        public IEnumerable<Office> GetAll()
        {
            return _context.Office.ToList();
        }
    }
}
