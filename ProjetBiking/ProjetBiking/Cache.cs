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
    // Classe générique qui contient un objet cache et les méthodes pour l'administrer
    class Cache<T> where T : new()
    {
        // Cet attribut est placé dans l'optique de l'amélioration de ce projet, dans le cas où on souhaiterait spécifier un délai spécifique au cache
        public static DateTimeOffset dt_default;
        public static ObjectCache cache;
        static private HttpClient client = new HttpClient();

        // Vérifie si l'item est dans le cache : si oui elle le retourne, sinon, elle va le chercher grâce à l'url placé en paramètre,
        // elle le met dans le cache et retourne finalement l'item
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
            return (T)cache.Get(name);
        }
        // Récupère la liste des items demandés à l'url spécifiée
        public static List<T> getItems(string url)
        {
            Task<string> response = client.GetStringAsync(url);
            response.Wait();
            return JsonConvert.DeserializeObject<List<T>>(response.Result);
        }
        // Ajoute une valeur dans le cache
        public static void set(string CacheItemKey, T CacheItem)
        {
            var item = cache.Get(CacheItemKey);
            if (item == null)
            {
                cache.Add(CacheItemKey, CacheItem, dt_default);
            }
        }
    }
}
