using ITA.Schedule.Entity;

namespace ITA.Schedule.DAL.Repositories.Interfaces
{
    /// <summary>
    /// Interface to be implemented by Dictionary repository
    /// </summary>
    /// <typeparam name="TDEntity"></typeparam>
    public interface IDictionaryRepository<TDEntity> where TDEntity : DictionaryEntity
    {
        // returns an entity found in the DB by code
        TDEntity GetByCode(int code);
    }
}