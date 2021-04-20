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
        OpenRouteServiceItinary GetItinarySOAP(string startAddress, string endAddress, string type, string ville);
        [OperationContract]
        OpenRouteServiceItem getCoordinatesFromAddress(string address);
        [OperationContract]
        int Sub(int Number1, int Number2);
        [OperationContract]
        int Mul(int Number1, int Number2);
        [OperationContract]
        int Div(int Number1, int Number2);

    }

    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }

}
