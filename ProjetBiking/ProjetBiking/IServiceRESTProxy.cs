using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    [ServiceContract]
    public interface IServiceRESTProxy
    {
        [OperationContract]
        [WebGet(UriTemplate = "/GetItem?name={name}&url={url}", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json
        )]
        JCDecauxItem getItem(string name, string url);
        [OperationContract]
        [WebGet(UriTemplate = "/GetItems?url={url}", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json
        )]
        List<JCDecauxItem> getItems(string url);
        [OperationContract]
        [WebGet(UriTemplate = "/GetCity/{city}", RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json
        )]
        string getCity(string city);
    }
}
