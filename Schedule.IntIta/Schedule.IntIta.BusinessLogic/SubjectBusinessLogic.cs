using System;
using System.Collections.Generic;
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
            return _repository.Get(id);
        }
        public void Update(Subject modifiedItem)
        {
            _repository.Update(modifiedItem);
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
        public IEnumerable<Subject> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
