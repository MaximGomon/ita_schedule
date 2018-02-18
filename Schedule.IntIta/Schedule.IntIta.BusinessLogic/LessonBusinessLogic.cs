using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Schedule.IntIta.DataAccess;
using Schedule.IntIta.Domain.Models;

namespace Schedule.IntIta.BusinessLogic
{
    public class LessonBusinessLogic : ILessonBusinessLogic
    {
        private readonly ILessonRepository _repository;

        public LessonBusinessLogic(ILessonRepository repository)
        {
            _repository = repository;
        }

        public void Add(Lesson item)
        {
            
            _repository.Insert(item);
        }
        
        

        public Lesson Read(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Lesson modifiedItem)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
