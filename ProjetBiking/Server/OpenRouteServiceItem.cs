using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    [DataContract]
    public class OpenRouteServiceItem
    {
        public OpenRouteServiceItem() { }
        [DataMember]
        public Feature[] features { get; set; }

    }
    [DataContract]
    public class Property
    {
        public Property() { }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string country { get; set; }
        [DataMember]
        public string county { get; set; }
    }
    [DataContract]
    public class Feature
    {
        public Feature() { }
        [DataMember]
        public Property properties { get; set; }
        [DataMember]
        public Geometry geometry { get; set; }
    }
    [DataContract]
    public class Geometry
    {
        public Geometry() { }
        [DataMember]
        public double[] coordinates { get; set; }
    }
}