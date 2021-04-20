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
        public static Position makePosition(OpenRouteServiceItem item, string ville)
        {
            Position result = null;
            foreach (Feature point in item.features)
            {
                if (point.properties.county.ToLower() == ville)
                {
                   result = new Position(Convert.ToDouble(point.geometry.coordinates[1]), Convert.ToDouble(point.geometry.coordinates[0]));
                    break;
                } 
            }
            if (result != null)
            {
                result = new Position(Convert.ToDouble(item.features[0].geometry.coordinates[1]), Convert.ToDouble(item.features[0].geometry.coordinates[0]));
            }
            // si pas de position disponible dans la ville on retourne la première de la liste

            return result;
        }
        public static OpenRouteServiceItinary getWay(Position s, Position e, string type, string ville)
        {
            string url = "https://api.openrouteservice.org/v2/directions/" + type + "?api_key=" + key + "=&start=" + e.longitude.ToString().Replace(",", ".") + "," + e.latitude.ToString().Replace(",", ".") + "&end=" + s.longitude.ToString().Replace(",", ".") + "," + s.latitude.ToString().Replace(",", ".");
            Task<string> response = client.GetStringAsync(url);
            response.Wait();
            return JsonConvert.DeserializeObject<OpenRouteServiceItinary>(response.Result);
        }
        public static OpenRouteServiceItinary getItinary(string startAddress, string endAddress, string type, string city)
        {
            Position s = makePosition(getCoordinatesFromAddress(startAddress), city);
            Position e = makePosition(getCoordinatesFromAddress(endAddress), city);
            return getWay(s, e, type, city);
        }

    }
}
