using System;
using System.Threading;

namespace Schedule.IntIta.Cache.Cache
{
    public class CacheManager<T> : ICacheManager<T>
    {
        private ICacheStore<T> _store;
        private IDataProvider<T> _dataProvider;
        public CacheManager(ICacheStore<T> store, IDataProvider<T> provider)
        {
            _store = store;
            _dataProvider = provider;
            Call();
            
        }
        public void Call()
        {
            bool flag = false;
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(15);
            var timer = new Timer((e) =>
            {
                _store.Clean();
                flag = true;

            }, null,startTimeSpan, periodTimeSpan);
            if (flag == true)
            {
               _store.SetData(_dataProvider.GetData());
            }
            
        }
    }
}
