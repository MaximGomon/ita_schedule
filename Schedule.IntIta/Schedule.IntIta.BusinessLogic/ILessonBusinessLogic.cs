using Schedule.IntIta.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.IntIta.BusinessLogic
{
    public interface ILessonBusinessLogic
    {
        void Add(Lesson item);
        Lesson Read(int id);
        void Update(Lesson modifiedItem);
        void Delete(int id);
    }
}
