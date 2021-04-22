using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    // Cet item regroupe toute les informations d'un itinéraire d'OpenRouteService

    [DataContract]
    public class OpenRouteServiceItinary
    {
        public OpenRouteServiceItinary() { }
        [DataMember]
        public FeatureI[] features { get; set; }

    }
    [DataContract]
    public class PropertyI
    {
        public PropertyI() { }
        [DataMember]
        public Segment[] segments { get; set; }
    }
    [DataContract]
    public class FeatureI
    {
        public FeatureI() { }
        [DataMember]
        public PropertyI properties { get; set; }
        [DataMember]
        public GeometryI geometry { get; set; }
    }
    [DataContract]
    public class Segment
    {
        public Segment() { }
        [DataMember]
        public double distance { get; set; }
        [DataMember]
        public double duration { get; set; }
    }
    [DataContract]
    public class GeometryI
    {
        public GeometryI() { }
        [DataMember]
        public float[][] coordinates { get; set; }
    }
}
