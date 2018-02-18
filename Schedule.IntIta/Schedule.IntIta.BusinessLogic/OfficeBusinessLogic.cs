using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Schedule.IntIta.DataAccess;
using Schedule.IntIta.Domain.Models;

namespace Schedule.IntIta.BusinessLogic
{
    public class OfficeBusinessLogic : IOfficeBusinessLogic
    {
        private readonly IOfficeRepository _repository;

        public OfficeBusinessLogic(IOfficeRepository repository)
        {
            _repository = repository;
        }

        public void Add(Office item)
        {
            if (string.IsNullOrEmpty(item.Name))
                throw new ValidationException("Parameter Name must have value!");

            if (_repository.GetAll().Any(x => string.Equals(x.Name, item.Name)))
                throw new ArgumentException("Office with the same name already exists!");

            _repository.Insert(item);
        }

        public Office Read(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Office modifiedItem)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
