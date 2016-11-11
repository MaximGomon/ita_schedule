using System.Collections.Generic;
using System.Linq;
using ITA.Schedule.Entity;

namespace ITA.Schedule.BLL.Interface
{
    public interface IDictionaryBl : ICrudBl<DictionaryEntity>
    {
        IQueryable<DictionaryEntity> GetByCode(int code);
    }
  
}