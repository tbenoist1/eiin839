using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
// REST Service
namespace Server
{
    [ServiceContract]
    public interface IServiceREST
    {
        [OperationContract]
        [WebGet(UriTemplate = "/GetItinary/{startAddress}/{endAddress}/{city}", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json
        )]
        List<OpenRouteServiceItinary> GetItinaryREST(string startAddress, string endAddress, string city);
        [OperationContract]
        [WebGet(UriTemplate = "/Sub/{Number1}/{Number2}", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json
        )]
        int SubRest(string Number1, string Number2);
    }
}
