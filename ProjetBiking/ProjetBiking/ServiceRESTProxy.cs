using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Caching;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Proxy
{
    // Implémentation de l'interface du Proxy
    // Cette implémentation est spécifique à JCDecaux.
    // En revanche la classe (Cache) qui représente le cache et qui est appelée ici est générique
    //
    // Les méthodes sont expliquées directement dans la classe Cache.
    [DataContract]
    public class ServiceRESTProxy : IServiceRESTProxy
    {
        public static HttpClient client = new HttpClient();
        public ServiceRESTProxy()
        {}
        public JCDecauxItem getItem(string name, string url)
        {
            return Cache<JCDecauxItem>.getItem(name, url);
        }
        public List<JCDecauxItem> getItems(string url)
        {
            return Cache<JCDecauxItem>.getItems(url);
        }
        public static void set(string cacheItemKey, JCDecauxItem cacheItem)
        {
            Cache<JCDecauxItem>.set(cacheItemKey, cacheItem);
        }
        public string getCity(string city)
        {
            return city;
        }
    }
}
