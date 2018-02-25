using Schedule.IntIta.Domain.Models;

namespace Schedule.IntIta.BusinessLogic
{
    public interface ISubjectBusinessLogic
    {
        void Add(Subject item);
        Subject Read(int id);
        void Update(Subject modifiedItem);
        void Delete(int id);
    }
}
