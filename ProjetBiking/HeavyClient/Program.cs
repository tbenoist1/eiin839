using HeavyClient.SOAPReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HeavyClient
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("SALUT A TOUS LES AMIS");
            SOAPReference.IServiceSOAP soap = new SOAPReference.ServiceSOAPClient();
            // Console.WriteLine(HttpUtility.UrlEncode("https://api.jcdecaux.com/vls/v3/stations?contract=nantes&apiKey=fd8a1c81d81337532f88e746a545e0721fe29ccc"));
            // OpenRouteServiceItem d = soap.getCoordinatesFromAddress("Chemin%20du%20Carrelot");
            // OpenRouteServiceItem a = soap.getCoordinatesFromAddress("Avenue%20Bernard%20Maris");

            // Console.WriteLine(d.features[0].properties.county);
            // Console.WriteLine(a.features[0].properties.county);
            // OpenRouteServiceItinary tamere = soap.GetItinarySOAP("Chemin%20du%20Carrelot", "Avenue%20Bernard%20Maris", "driving-car", "toulouse");
            // Console.WriteLine(tamere.features[0].properties.segments[0].distance);
            // Console.WriteLine(tamere.);
            while (true)
            {
            }
        }
    }
}
