using System;
using System.Collections.Generic;
using System.Linq;
using Schedule.IntIta.Domain.Models;
using Schedule.IntIta.DataAccess.Context;

namespace Schedule.IntIta.DataAccess
{
    public class SubjectRepository : ISubjectRepository
    {
        public void Insert(Subject item)
        {
            using (var context = new IntitaDbContext())
            {
                context.Subjects.Add(item);
                context.SaveChanges();
            }
        }

        public Subject Get(int id)
        {
            using (var context = new IntitaDbContext())
            {
                var subject = context.Subjects
                    .Single(s => s.Id == id);
                return subject;
            }
        }

        public void Update(Subject modifiedItem)
        {
            using (var context = new IntitaDbContext())
            {
                context.Subjects.Update(modifiedItem);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new IntitaDbContext())
            {
                var subject = context.Subjects
                    .Single(s => s.Id == id);
                subject.IsDeleted = true;
                context.SaveChanges();
            }   
        }

        public IEnumerable<Subject> GetAll()
        {
            using (var context = new IntitaDbContext())
            {
                //return context.Subjects.Where(s => s.IsDeleted == false).ToList();
                return context.Subjects.ToList();
            }
        }
    }
}