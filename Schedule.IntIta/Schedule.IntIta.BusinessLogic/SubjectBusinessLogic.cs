using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Schedule.IntIta.DataAccess;
using Schedule.IntIta.Domain.Models;

namespace Schedule.IntIta.BusinessLogic
{
    public class SubjectBusinessLogic : ISubjectBusinessLogic
    {
        private readonly ISubjectRepository _repository;
        public SubjectBusinessLogic(ISubjectRepository repository)
        {
            _repository = repository;
        }
        public void Add(Subject item)
        {
            _repository.Insert(item);
        }
        public Subject Read(int id)
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
    }
}
