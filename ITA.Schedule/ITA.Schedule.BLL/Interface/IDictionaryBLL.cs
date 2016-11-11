using System.Collections.Generic;
using System.Linq;
using ITA.Schedule.Entity;

namespace ITA.Schedule.BLL.Interface
{
    public interface IDictionaryBll : ICrudBll<DictionaryEntity>
    {
        IQueryable<DictionaryEntity> GetByCode(int code);
    }
  
}