using System;
using System.Collections.Generic;
using System.Linq;
using Schedule.IntIta.Domain.Models;
using Schedule.IntIta.DataAccess.Context;

namespace Schedule.IntIta.DataAccess
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly IntitaDbContext _context;
        public SubjectRepository(IntitaDbContext context)
        {
            _context = context;
        }
        public void Insert(Subject item)
        {
            _context.Subjects.Add(item);
            _context.SaveChanges();
        }

        public Subject Get(int id)
        {
            var subject = _context.Subjects
                .Single(s => s.Id == id);
            return subject;
        }

        public void Update(Subject modifiedItem)
        {
            _context.Subjects.Update(modifiedItem);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var subject = _context.Subjects
                .Single(s => s.Id == id);
            subject.IsDeleted = true;
            _context.SaveChanges();
        }

        public IEnumerable<Subject> GetAll()
        {
            return _context.Subjects.ToList();
        }
    }
}