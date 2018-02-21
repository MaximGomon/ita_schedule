using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schedule.IntIta.Cache.Cache
{
    public class CacheStore<T> : ICacheStore<T>
    {
        private List<T> list;
        public void SetData(IEnumerable<T> items)
        {
            list = items.ToList();
        }
        public IEnumerable<T> GetData()
        {
            return list;
        }
        public void Clean()
        {
            list.Clear();
        }
    }
}
