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
        // La liste des stations JCDecaux disponible par l'API JCDecaux
        public static List<JCDecauxItem> stations = new List<JCDecauxItem>();
        public Services()
        {
            // Au démarrage du Serveur, on récupère toutes les stations disponibles
            getStations();
        }

        public OpenRouteServiceItinary GetItinarySOAP(string start, string end, string type)
        {
            return OpenRouteServiceAPI.getItinary(start, end, type);
        }
        public List<ProjetBikingItem> GetItinaryREST(string start, string end)
        {
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "*");
            List<ProjetBikingItem> results = new List<ProjetBikingItem>();
            OpenRouteServiceItem startCoordinates =  OpenRouteServiceAPI.getCoordinatesFromAddress(start);
            Position startedWantedPoint = OpenRouteServiceAPI.makePosition(startCoordinates);
            List<JCDecauxItem> stationsProximityStart = JCDecauxAPI.sortStationsByProximity(startedWantedPoint.latitude,startedWantedPoint.longitude, stations);
            Position endedWantedPoint = OpenRouteServiceAPI.makePosition(OpenRouteServiceAPI.getCoordinatesFromAddress(end)); ;
            List<JCDecauxItem> stationsProximityEnd = JCDecauxAPI.sortStationsByProximity(endedWantedPoint.latitude, endedWantedPoint.longitude, stations);
            // AB = Available Bikes
            List<JCDecauxItem> stationsProximityStartAB = JCDecauxAPI.listStationsWithBikesAvailabilities(stationsProximityStart);
            List<JCDecauxItem> stationsProximityEndAB = JCDecauxAPI.listStationsWithBikesAvailabilities(stationsProximityEnd);

            results.Add(new ProjetBikingItem(OpenRouteServiceAPI.getWay(startedWantedPoint, stationsProximityStartAB[0].position, OpenRouteServiceAPI.types[0]), stationsProximityStartAB.ToArray()));
            results.Add(new ProjetBikingItem(OpenRouteServiceAPI.getWay(stationsProximityStartAB[0].position, stationsProximityEndAB[0].position, OpenRouteServiceAPI.types[1]), stationsProximityEndAB.ToArray()));
            results.Add(new ProjetBikingItem(OpenRouteServiceAPI.getWay(endedWantedPoint, stationsProximityEndAB[0].position, OpenRouteServiceAPI.types[0]), null));

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
