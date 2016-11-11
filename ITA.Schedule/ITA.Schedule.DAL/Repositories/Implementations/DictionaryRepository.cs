using System.Linq;
using ITA.Schedule.DAL.Repositories.Interfaces;
using ITA.Schedule.Entity;

namespace ITA.Schedule.DAL.Repositories.Implementations
{
    /// <summary>
    /// Repository to perform CRUD operations ove rictionary entities
    /// </summary>
    public class DictionaryRepository<DictionaryTEntity> : CrudRepository<DictionaryTEntity>, IDictionaryRepository<DictionaryTEntity>
        where DictionaryTEntity : DictionaryEntity
    {
        // get dictionary entity from DB by code
        public DictionaryTEntity GetByCode(int code)
        {
            return ContextDb.Set<DictionaryTEntity>().FirstOrDefault(x => x.Code == code);
        }
    }
}