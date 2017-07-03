using ITA.Schedule.Entity;

namespace ITA.Schedule.DAL.Repositories.Interfaces
{
    /// <summary>
    /// Interface to be implemented by Dictionary repository
    /// </summary>
    public interface IDictionaryRepository<TDEntity> where TDEntity : DictionaryEntity
    {
        /// <summary>returns an entity found in the DB by code</summary>
        TDEntity GetByCode(int code);
    }
}