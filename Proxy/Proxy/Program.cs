using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Text.Json;
using System.Threading.Tasks;

namespace Proxy
{
    class Program
    {
        async static Task Main(string[] args)
        {
            DateTimeOffset date = DateTimeOffset.Now;
            ObjectCache cache = MemoryCache.Default;
            ProxyCache<JCDecauxItem> proxyCache = new ProxyCache<JCDecauxItem>();
            JCDecaux jcd = new JCDecaux("toulouse");
            List<JCDecauxItem> items = await JCDecaux.getAContract("toulouse");
            JCDecauxItem item = await JCDecaux.getStationNewsByContract(12, "toulouse"); ;
            Console.WriteLine(items[0].name);
            Console.WriteLine(item);
            proxyCache.set(items[0].name, items[0]);
            proxyCache.set(items[1].name, items[1]);
            JCDecauxItem deux = JCDecaux.getJCDecauxItemByName("00007 - PLACE VICTOR HUGO");
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
                JCDecauxItem i = JCDecaux.getJCDecauxItemByName(name);
                JCDecauxItem itemToReturn = await JCDecaux.getStationNewsByContract(i.number, i.contractName);
                cache.set(name, itemToReturn);
                return itemToReturn;
            }
            return cache.getItem(name);
        }
    }

}
