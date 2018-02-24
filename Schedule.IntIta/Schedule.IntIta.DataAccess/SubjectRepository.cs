using System;
using System.Collections.Generic;
using Schedule.IntIta.Domain.Models;

namespace Schedule.IntIta.DataAccess
{
    public class SubjectRepository : ISubjectRepository
    {
        public void Insert(Subject item)
        {
            throw new System.NotImplementedException();
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