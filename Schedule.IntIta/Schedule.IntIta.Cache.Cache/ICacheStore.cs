using System.Collections.Generic;

namespace Schedule.IntIta.Cache.Cache
{
    public interface ICacheStore<T>
    {
      void SetData(IEnumerable<T> items);
      IEnumerable<T> GetData();
      void Clean();
    }
}