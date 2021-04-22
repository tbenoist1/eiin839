using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

// SOAP Service
namespace Server
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IServiceSOAP
    {
        [OperationContract]
        OpenRouteServiceItinary GetItinarySOAP(string startAddress, string endAddress, string type);
        [OperationContract]
        OpenRouteServiceItem getCoordinatesFromAddress(string address);

    }
}
