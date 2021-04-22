using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Server
{
    class OpenRouteServiceAPI
    {
        private static string key = "5b3ce3597851110001cf62480d05f646f4134b3697502d98a19e0900";
        static HttpClient client = new HttpClient();
        public static string[] types = { "foot-walking", "cycling-regular" };
        public static OpenRouteServiceItem getCoordinatesFromAddress(string address)
        {
            Task<string> response = client.GetStringAsync("https://api.openrouteservice.org/geocode/search?api_key=" + key + "&text=" + address);
            response.Wait();
            return JsonConvert.DeserializeObject<OpenRouteServiceItem>(response.Result);
        }
        public static Position makePosition(OpenRouteServiceItem item)
        {
            Position result = null;
            foreach (Feature point in item.features)
            {
                result = new Position(Convert.ToDouble(point.geometry.coordinates[1]), Convert.ToDouble(point.geometry.coordinates[0]));
                break;
            }
            return result;
        }
        public static OpenRouteServiceItinary getWay(Position s, Position e, string type)
        {
            string url = "https://api.openrouteservice.org/v2/directions/" + type + "?api_key=" + key + "=&start=" + e.longitude.ToString().Replace(",", ".") + "," + e.latitude.ToString().Replace(",", ".") + "&end=" + s.longitude.ToString().Replace(",", ".") + "," + s.latitude.ToString().Replace(",", ".");
            Task<string> response = client.GetStringAsync(url);
            response.Wait();
            return JsonConvert.DeserializeObject<OpenRouteServiceItinary>(response.Result);
        }
        public static OpenRouteServiceItinary getItinary(string startAddress, string endAddress, string type)
        {
            Position s = makePosition(getCoordinatesFromAddress(startAddress));
            Position e = makePosition(getCoordinatesFromAddress(endAddress));
            return getWay(s, e, type);
        }

    }
}
