using System;
using System.Collections.Generic;
using System.Text;
using Schedule.Intita.ApiRequest;

namespace Schedule.IntIta.Cache.Cache
{
    public class CacheDataProvider <T> : IDataProvider<T>
    {
        public IEnumerable<T> GetData()
        {
            ApiRequest<List<T>> apiRequest = new ApiRequest<List<T>>();
            var response = apiRequest.Url("https://sso.intita.com/api/")
                .Authenticate()
                .Get()
                .Send();
            return response.Response;
           
        }
    }
}
