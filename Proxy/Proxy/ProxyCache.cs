using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;

namespace Proxy
{
    class ProxyCache<T>
    where T : class, new()
    {
        public DateTimeOffset dt_default;
        ObjectCache cache;
        public ProxyCache(ObjectCache c, DateTimeOffset d)
        {
            this.cache = c;
            this.dt_default = d;
        }
        public ProxyCache()
        {
            dt_default = ObjectCache.InfiniteAbsoluteExpiration;
            cache = MemoryCache.Default;
        }
        public bool contains(string name)
        {
            if (cache.Contains(name))
            {
                return true;
            }
            return false;
        }
        public void set(string CacheItemKey, T CacheItem)
        {
            var item = cache.Get(CacheItemKey);

            if (item == null)
            {
                cache.Add(CacheItemKey, CacheItem, dt_default);
            }
            foreach (var i in cache)
            {
                Console.WriteLine("cache object key-value: " + i.Key + "-" + i.Value);
            }
        }
        public void set(string CacheItem, double dt_seconds)
        {
            var item = cache.Get(CacheItem);

            if (item == null)
            {
                cache.Add(CacheItem, new T(), DateTimeOffset.Now.AddSeconds(dt_seconds));
            }
        }
        public void set(string CacheItem, DateTimeOffset dt)
        {
            var item = cache.Get(CacheItem);
            if (item == null)
            {
                cache.Add(CacheItem, new T(), dt);
            }
        }
        public void setDelay(DateTimeOffset def)
        {
            this.dt_default = def;
        }
        public T getItem(string key)
        {
            return (T)cache.Get(key);
        }

    }
}
