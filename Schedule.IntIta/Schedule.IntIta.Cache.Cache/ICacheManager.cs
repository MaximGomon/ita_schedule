using System.Collections;
using System.Collections.Generic;

namespace Schedule.IntIta.Cache.Cache
{
    public interface ICacheManager<T>
    {
        IEnumerable<T> Call();
    }
}