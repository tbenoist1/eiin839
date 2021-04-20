using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;

namespace Proxy
{
    class Program
    {
/*        async static void Main(string[] args)
        {
            DateTimeOffset date = DateTimeOffset.Now;
            ObjectCache cache = MemoryCache.Default;
            //Va dans Service1.cs
            ProxyCache<JCDecauxItem> proxyCache = new ProxyCache<JCDecauxItem>();
            JCDecauxAPI jcd = new JCDecauxAPI("toulouse");
            List<JCDecauxItem> items = await JCDecauxAPI.getAContract("toulouse");
            JCDecauxItem item = await JCDecauxAPI.getStationNewsByContract(12, "toulouse"); ;
            Console.WriteLine(items[0].name);
            Console.WriteLine(item);
            proxyCache.set(items[0].name, items[0]);
            proxyCache.set(items[1].name, items[1]);
            JCDecauxItem deux = JCDecauxAPI.getJCDecauxItemByName("00007 - PLACE VICTOR HUGO");
            Console.WriteLine(deux.address);
            await getStation(proxyCache, items[14].name);
            while (true)
            {
            }

        }
        async static Task<JCDecauxItem> getStation(ProxyCache<JCDecauxItem> cache, string name)
        {
            if (cache.contains(name) == false)
            {
                // Transformer les deux lignes suivantes par une URL
                JCDecauxItem i = JCDecauxAPI.getJCDecauxItemByName(name);
                JCDecauxItem itemToReturn = await JCDecauxAPI.getStationNewsByContract(i.number, i.contractName);
                cache.set(name, itemToReturn);
                return itemToReturn;
            }
            return cache.getItem(name);
        }*/
/*        static void CallingSOAPfunction()
        {
            Service1Client proxy = new Service1Client("SOAPEndPoint");
            var result = proxy.Add(7, 2);
            Console.WriteLine(result);
        }
        static void CallingRESTfunction()
        { 
            WebClient RESTProxy = new WebClient();
            byte[] data = RESTProxy.DownloadData(new Uri("http://localhost:30576/Service1.svc/Rest/add/7/2"));
            Stream stream = new MemoryStream(data);
            DataContractJsonSerializer obj = new DataContractJsonSerializer(typeof(string));
            string result = obj.ReadObject(stream).ToString();
            Console.WriteLine(result);
        }*/
    }
}
