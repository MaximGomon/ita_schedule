using System.Linq;
using ITA.Schedule.DAL.Repositories.Interfaces;
using ITA.Schedule.Entity;

namespace ITA.Schedule.DAL.Repositories.Implementations
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TDEntity"></typeparam>
    public class DictionaryRepository<TDEntity> : CrudRepository<TDEntity>, IDictionaryRepository<TDEntity>
        where TDEntity : DictionaryEntity
    {
        // get dictionary entity from DB by code
        public TDEntity GetByCode(int code)
        {
            return ContextDb.Set<TDEntity>().FirstOrDefault(x => x.Code == code);
        }
    }
}