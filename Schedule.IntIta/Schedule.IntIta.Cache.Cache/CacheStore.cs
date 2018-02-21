
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace Schedule.IntIta.Cache.Cache
{
    public class CacheStore<T> : ICacheStore<T>
    {
        private List<T> list;
        public bool IsLoaded { get; set; }
        public void SetData(IEnumerable<T> items)
        {
            list = items.ToList();
            IsLoaded = true;
        }
        public IEnumerable<T> GetData()
        {
            if(IsLoaded ==false)
            {
                throw new DataException("Cache was not loaded");
            }
            return list;
        }
        public void Clean()
        {
            list.Clear();
            IsLoaded = false;
        }
    }
}
