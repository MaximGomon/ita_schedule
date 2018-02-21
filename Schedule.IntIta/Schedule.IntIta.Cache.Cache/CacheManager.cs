using System;
using System.Collections.Generic;
using System.Threading;

namespace Schedule.IntIta.Cache.Cache
{
    public class CacheManager<T> : ICacheManager<T>
    {
        private Timer _timer;
        private ICacheStore<T> _store;
        private IDataProvider<T> _dataProvider;
        public CacheManager(ICacheStore<T> store, IDataProvider<T> provider)
        {
            _timer = new Timer((e) =>
            {
                if (_store.IsLoaded == true)
                {
                    _store.Clean();
                }

            }, null, TimeSpan.Zero, TimeSpan.FromMinutes(15));
            _store = store;
            _dataProvider = provider;
                        
        }
        public IEnumerable<T> Call()
        {
            if(_store.IsLoaded == false)
            {
                _store.SetData(_dataProvider.GetData());
            }
           return _store.GetData();
        }
    }
}
