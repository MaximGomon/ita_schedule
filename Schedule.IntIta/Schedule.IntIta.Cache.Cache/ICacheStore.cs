using System.Collections.Generic;

namespace Schedule.IntIta.Cache.Cache
{
    public interface ICacheStore<T>
    {
      bool IsLoaded { get; set; }
      void SetData(IEnumerable<T> items);
      IEnumerable<T> GetData();
      void Clean();
    }
}