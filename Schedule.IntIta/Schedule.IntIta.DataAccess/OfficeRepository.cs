using System;
using System.Collections.Generic;
using System.Linq;
using Schedule.IntIta.DataAccess.Context;
using Schedule.IntIta.Domain.Models;

namespace Schedule.IntIta.DataAccess
{
    public class OfficeRepository : IOfficeRepository
    {
        public void Insert(Office item)
        {
            using (var context = new IntitaDbContext())
            {
                context.Office.Add(item);
                context.SaveChanges();
            }
        }

        public Office Get(int id)
        {
            using (var context = new IntitaDbContext())
            {
                var office = context.Office
                    .Single(s => s.Id == id);
                return office;
            }
        }

        public void Delete(int id)
        {
            using (var context = new IntitaDbContext())
            {
                var office = context.Office
                    .Single(s => s.Id == id);
                office.IsDeleted = true;
                context.SaveChanges();
            }
        }

        public void Update(Office modifiedItem)
        {
            using (var context = new IntitaDbContext())
            {
                context.Office.Update(modifiedItem);
                context.SaveChanges();
            }
        }

        public IEnumerable<Office> GetAll()
        {
            using (var context = new IntitaDbContext())
            {
                return context.Office.ToList();
            }
        }
    }
}
