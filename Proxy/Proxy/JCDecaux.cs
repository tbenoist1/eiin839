using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

using System.Text.Json;

namespace Proxy
{
    class JCDecaux
    {
        // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        static private HttpClient client;
        static private string apiJCDecauxURL = "https://api.jcdecaux.com/vls/v3/stations";
        static private string key = "fd8a1c81d81337532f88e746a545e0721fe29ccc";
        static private Task<List<JCDecauxItem>> stations;

        public JCDecaux(string ville)
        {
            client = new HttpClient();
            stations = getAContract(ville);
        }
        public JCDecaux()
        {
            client = new HttpClient();
        }
        public static Task<List<JCDecauxItem>> getStations()
        {
            return stations;
        }
        async static public Task<List<JCDecauxItem>> getAContract(string param)
        {
            var response = await client.GetStreamAsync(apiJCDecauxURL + "?contract=" + param + "&apiKey=" + key);
            JsonDocument contract = await JsonDocument.ParseAsync(response);
            return JsonSerializer.Deserialize<List<JCDecauxItem>>(contract.RootElement.ToString());
        }
/*        public static async Task<JCDecauxItem> getContracts()
        {
            var response = await client.GetStreamAsync(apiJCDecauxURL + "?&apiKey=" + key);
            JsonDocument contracts = await JsonDocument.ParseAsync(response);
            return contracts.RootElement;
        }*/
        async static public Task<JCDecauxItem> getStationNewsByContract(int id, string city)
        {
            var response = await client.GetStreamAsync(apiJCDecauxURL + "/" + id + "?contract=" + city + "&apiKey=" + key);
            JsonDocument station = await JsonDocument.ParseAsync(response);
            return JsonSerializer.Deserialize<JCDecauxItem>(station.RootElement.ToString());

        }
        static public String[] listStations(JsonElement stations)
        {
            int numberStations = stations.GetArrayLength();
            String[] s = new string[numberStations];
            for (int i = 0; i < numberStations; i++)
            {
                s[i] = stations[i].GetProperty("name").ToString();
                Console.WriteLine(stations[i].GetProperty("name").ToString());
            }
            Console.WriteLine(stations[0]);
            return s;
        }
        static public bool isAnyBike(JCDecauxItem i)
        {
            if (i.mainStands.availabilities.bikes > 0)
            {
                return true;
            }
            return false;
        }
        static public List<JCDecauxItem> listStationsWithBikesAvailabilities(List<JCDecauxItem> items)
        {
            int numberStations = items.Count;
            List<JCDecauxItem> jcdi = new List<JCDecauxItem>();
            for (int i = 0; i < numberStations; i++)
            {
                if (isAnyBike(items[i]))
                {
                    jcdi.Add(items[i]);
                }
            }
            return jcdi;
        }
        static public JCDecauxItem getJCDecauxItemByName(string name)
        {
            return stations.Result.Find(x => x.name.Contains(name));
        }
    }

}
