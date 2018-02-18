using System;
using System.Collections.Generic;
using Schedule.IntIta.Domain.Models;

namespace Schedule.IntIta.DataAccess
{
    public interface ILessonRepository
    {
        void Insert(Lesson item);
        Lesson Get(int id);
        void Update(Lesson modifiedItem);
        void Delete(int id);
        IEnumerable<Lesson> GetAll();
    }
}
