using System.Collections.Generic;

namespace Schedule.IntIta.Cache.Cache
{
    public interface IDataProvider<T>
    {
        IEnumerable<T> GetData();
    }
}