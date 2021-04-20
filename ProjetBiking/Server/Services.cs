using System;
using System.Collections.Generic;
using System.Net.Http;
using System.ServiceModel.Web;
using System.Text.Json;
using System.Threading.Tasks;

namespace Server
{

    public class Services : IServiceSOAP, IServiceREST
    {
        public static List<JCDecauxItem> stations = new List<JCDecauxItem>();
        public static string city { get; set; }
        public Services()
        {
            getStations();
        }
        public int Add(int Number1, int Number2)
        {
            return Number1 + Number2;
        }

        public int Sub(int Number1, int Number2)
        {
            return Number1 - Number2;
        }

        public int Mul(int Number1, int Number2)
        {
            return Number1 * Number2;
        }

        public int Div(int Number1, int Number2)
        {
            return Number1 / Number2;
        }

        public int AddRest(string Number1, string Number2)
        {
            int num1 = Convert.ToInt32(Number1);
            int num2 = Convert.ToInt32(Number2);
            return num1 + num2;
        }

        public int SubRest(string Number1, string Number2)
        {
            int num1 = Convert.ToInt32(Number1);
            int num2 = Convert.ToInt32(Number2);
            return num1 - num2;
        }
        public OpenRouteServiceItinary GetItinarySOAP(string start, string end, string type, string ville)
        {
            return OpenRouteServiceAPI.getItinary(start, end, type, ville);
        }
        public List<OpenRouteServiceItinary> GetItinaryREST(string start, string end, string city)
        {
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "*");
            List<OpenRouteServiceItinary> results = new List<OpenRouteServiceItinary>();
            List<JCDecauxItem> stationsInCity = JCDecauxAPI.getStationsByCity(stations, city);
            OpenRouteServiceItem startCoordinates =  OpenRouteServiceAPI.getCoordinatesFromAddress(start);
            Position startedWantedPoint = OpenRouteServiceAPI.makePosition(startCoordinates, city);
            List<JCDecauxItem> stationsProximityStart = JCDecauxAPI.sortStationsByProximity(startedWantedPoint.latitude,startedWantedPoint.longitude, stationsInCity);
            Position endedWantedPoint = OpenRouteServiceAPI.makePosition(OpenRouteServiceAPI.getCoordinatesFromAddress(end), city); ;
            List<JCDecauxItem> stationsProximityEnd = JCDecauxAPI.sortStationsByProximity(endedWantedPoint.latitude, endedWantedPoint.longitude, stationsInCity);
            // AB = Available Bikes
            List<JCDecauxItem> stationsProximityStartAB = JCDecauxAPI.listStationsWithBikesAvailabilities(stationsProximityStart);
            List<JCDecauxItem> stationsProximityEndAB = JCDecauxAPI.listStationsWithBikesAvailabilities(stationsProximityEnd);

            results.Add(OpenRouteServiceAPI.getWay(startedWantedPoint, stationsProximityStartAB[0].position, OpenRouteServiceAPI.types[0], city));
            results.Add(OpenRouteServiceAPI.getWay(stationsProximityStartAB[0].position, stationsProximityEndAB[0].position, OpenRouteServiceAPI.types[1], city));
            results.Add(OpenRouteServiceAPI.getWay(endedWantedPoint, stationsProximityEndAB[0].position, OpenRouteServiceAPI.types[0], city));

            return results;
        }
        public OpenRouteServiceItem getCoordinatesFromAddress(string address)
        {
            return OpenRouteServiceAPI.getCoordinatesFromAddress(address);
        }
        static public void getStations()
        {
            stations = JCDecauxAPI.getStations();
        }
        static public JCDecauxItem getStationNewsByContract(int id, string city)
        {
            return JCDecauxAPI.getStationNewsByContract(id, city);
        }

    }
}
