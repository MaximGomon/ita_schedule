using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Schedule.IntIta.DataAccess;
using Schedule.IntIta.Domain.Models;

namespace Schedule.IntIta.BusinessLogic
{
    public class UserBusinessLogic : IUserBusinessLogic
    {
        private readonly IUserRepository _repository;

        public UserBusinessLogic(IUserRepository repository)
        {
            _repository = repository;
        }
        //public void Add(User user)
        //{
        //    if(string.IsNullOrEmpty(user.Login))
        //    {
        //        throw new ValidationException("Parameter Login must have Value");
        //    }
        //    if(_repository.GetByStr().Any(x => string.Equals(x.Login, user.Login)))
        //    {
        //        throw new ArgumentException("User with the same Login already exists!");
        //    }
        //    _repository.Insert(user);
        //}

        //public void Delete(int id)
        //{
        //    if (_repository.GetAll().Any(x => Equals(x.Id, id)))
        //    {
        //        _repository.Delete(id);
        //    }
        //    else
        //    {
        //        throw new ArgumentException("User with the same Id is not found!");
        //    }
        //}

        public User Read(int id)
        {
            return _repository.GetById(id);
        }

        public List<User> ReadByStr(string searchStr)
        {
            return _repository.GetByStr(searchStr);
        }

        public void Update(User modifiedUser)
        {
            throw new NotImplementedException();
        }
    }
}
