using Schedule.IntIta;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schedule.Intita.ApiRequest;
using Schedule.IntIta.Domain.Models;
using System.Linq;
using FakeItEasy;
using Schedule.IntIta.Cache.Cache;


namespace BusinessLogic.Test
{
    [TestClass]
    public class CacheManagerTest
    {
        [TestMethod]
        public void CreateCacheManagerTest()
        {
            ICacheStore<User> cacheStore = A.Fake<ICacheStore<User>>();
            A.CallTo(() => cacheStore.IsLoaded).Returns(true);
            A.CallTo(() => cacheStore.GetData()).Returns(Enumerable.Empty<User>());
            IDataProvider<User> dataProvider = A.Fake<IDataProvider<User>>();
            dataProvider = null;
            CacheManager<User> cacheManager = new CacheManager<User>(cacheStore, dataProvider);
            var items = cacheManager.Call();
            Assert.AreEqual(items, Enumerable.Empty<User>());
            
        }

        

        //dataprovider - null
        //store.IsLoaded - mock - return true
        //store.GetData - mock - return empty enumeration
        //check manager.GetData - must return empty enumeration from store


    }
}
