using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Collections.Specialized;
using Newtonsoft.Json;
using System.Web;
using System.Device.Location;

namespace Server
{
    class JCDecauxAPI
    {
        // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        static private HttpClient client = new HttpClient();
        static private string apiJCDecauxAPIURL = "https://api.jcdecaux.com/vls/v3/stations";
        static private string key = "fd8a1c81d81337532f88e746a545e0721fe29ccc";



        public JCDecauxAPI()
        {
            
        }
        static public List<JCDecauxItem> getStations()
        {
            string url = apiJCDecauxAPIURL + "?apiKey=" + key;
            Task<string> response = client.GetStringAsync("http://localhost:8733/Design_Time_Addresses/Proxy/rest/GetCity/toulouse");
            var x = "http://localhost:8733/Design_Time_Addresses/Proxy/rest/GetItems?url=" + HttpUtility.UrlEncode(url);
            Task<string> response1 = client.GetStringAsync(x);
            // response.Wait();
            response1.Wait();
            return JsonConvert.DeserializeObject<List<JCDecauxItem>>(response1.Result);
        }
        static public JCDecauxItem getStationNewsByContract(int id, string city)
        {
            string url = apiJCDecauxAPIURL + "/" + id + "?contract=" + city + "&apiKey=" + key;
            Task<string> response = client.GetStringAsync("http://localhost:8733/Design_Time_Addresses/Proxy/rest/GetItem/"+city+"/url="+ HttpUtility.UrlEncode(url));
            response.Wait();
            return JsonConvert.DeserializeObject<JCDecauxItem>(response.Result);

        }
        static public List<JCDecauxItem> getStationsByCity(List<JCDecauxItem> stations, string city)
        {
            int numberStations = stations.Count();
            List<JCDecauxItem> stationsInCity = new List<JCDecauxItem>();
            foreach (JCDecauxItem station in stations)
            {
                if (station.contractName == city)
                {
                    stationsInCity.Add(station);
                }
            }
            return stations;
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
            int numberStations = items.Count();
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
        /*        static public JCDecauxItem getJCDecauxItemByName(string name)
                {
                    return stations.Result.Find(x => x.name.Contains(name));
                }*/
        static public List<JCDecauxItem> sortStationsByProximity(double latitude, double longitude, List<JCDecauxItem> stations)
        {
            GeoCoordinate localization = new GeoCoordinate(latitude, longitude);
            SortedDictionary<double, JCDecauxItem> stationsSorted = new SortedDictionary<double, JCDecauxItem>();
            foreach (JCDecauxItem station in stations)
            {
                GeoCoordinate coordinates = new GeoCoordinate(Convert.ToDouble(station.position.latitude), Convert.ToDouble(station.position.longitude));
                double distance = localization.GetDistanceTo(coordinates);
                if (!stationsSorted.ContainsKey(distance))
                {
                    stationsSorted.Add(localization.GetDistanceTo(coordinates), station);
                }
                // Si on a deux stations à éxactement la même distance du point
                else
                {
                    stationsSorted.Add(localization.GetDistanceTo(coordinates) + 0.001, station);
                }
            }
            // On ajoute les items triés dans la liste finale
            List<JCDecauxItem> results = new List<JCDecauxItem>();
            foreach (KeyValuePair<double, JCDecauxItem> j in stationsSorted)
            {
                results.Add(j.Value);
            }
            return results;
        }
    }

}
