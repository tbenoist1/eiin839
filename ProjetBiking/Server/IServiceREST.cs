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
        [WebGet(UriTemplate = "/GetItinary/{startAddress}/{endAddress}", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json
        )]
        List<ProjetBikingItem> GetItinaryREST(string startAddress, string endAddress);
    }
}
