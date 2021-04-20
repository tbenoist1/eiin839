using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace Proxy
{
    class Utils<T> where T : new()
    {
        public static DateTimeOffset dt_default;
        public static ObjectCache cache;
        static private HttpClient client = new HttpClient();
        public static T getItem(string name, string url)
        {
            if (cache.Contains(name) == false)
            {
                var x = HttpUtility.UrlDecode(url);
                Task<string> response = client.GetStringAsync(x);
                response.Wait();
                T itemToReturn = JsonConvert.DeserializeObject<T>(response.Result);
                set(name, itemToReturn);
                return itemToReturn;
            }
            return getItemA(name);
        }
        public static List<T> getItems(string url)
        {
            Task<string> response = client.GetStringAsync(url);
            response.Wait();
            return JsonConvert.DeserializeObject<List<T>>(response.Result);
        }
        public static void set(string CacheItemKey, T CacheItem)
        {
            var item = cache.Get(CacheItemKey);
            if (item == null)
            {
                cache.Add(CacheItemKey, CacheItem, dt_default);
            }
        }
        public static T getItemA(string key)
        {
            return (T)cache.Get(key);
        }
    }
}
