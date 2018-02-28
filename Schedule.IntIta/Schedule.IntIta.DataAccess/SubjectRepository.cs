using System;
using System.Collections.Generic;
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
            throw new System.NotImplementedException();
        }

        public IEnumerable<Subject> GetFreeRooms(DateTime forDate)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Subject modifiedItem)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Subject> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}