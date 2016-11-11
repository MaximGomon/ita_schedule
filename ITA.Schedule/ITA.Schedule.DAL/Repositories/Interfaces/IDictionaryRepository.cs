using ITA.Schedule.Entity;

namespace ITA.Schedule.DAL.Repositories.Interfaces
{
    /// <summary>
    /// Interface to be implemented by Dictoionary repository
    /// </summary>
    /// <typeparam name="DictionaryEntity"></typeparam>
    public interface IDictionaryRepository<DictionaryTEntity> where DictionaryTEntity : DictionaryEntity
    {
        // returns an entity found in the DB by code
        DictionaryTEntity GetByCode(int code);
    }
}