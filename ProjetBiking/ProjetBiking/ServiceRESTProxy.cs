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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    [DataContract]
    public class ServiceRESTProxy : IServiceRESTProxy
    {
        public static HttpClient client = new HttpClient();
        public ServiceRESTProxy()
        {
            
        }
        public int SubRest(string Number1, string Number2)
        {
            int num1 = Convert.ToInt32(Number1);
            int num2 = Convert.ToInt32(Number2);
            return num1 - num2;
        }
        public JCDecauxItem getItem(string name, string url)
        {
            return Utils<JCDecauxItem>.getItem(name, url);
        }
        public List<JCDecauxItem> getItems(string url)
        {
            return Utils<JCDecauxItem>.getItems(url);
        }
        public static void set(string cacheItemKey, JCDecauxItem cacheItem)
        {
            Utils<JCDecauxItem>.set(cacheItemKey, cacheItem);
        }
        public static JCDecauxItem getItemA(string key)
        {
            return Utils<JCDecauxItem>.getItemA(key);
        }
        public string getCity(string city)
        {
            return city;
        }
    }
}
