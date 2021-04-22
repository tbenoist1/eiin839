using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    // Cet item regroupe toute les informations d'un item du Projet soit un itinéraire OpenRouteService et une liste de stations JCDecaux

    [DataContract]
    public class ProjetBikingItem
    {
        public ProjetBikingItem() { }
        public ProjetBikingItem(OpenRouteServiceItinary i, JCDecauxItem[] s) {
            itinary = i;
            stations = s;
        }
        [DataMember]
        public OpenRouteServiceItinary itinary { get; set; }
        [DataMember]
        public JCDecauxItem[] stations { get; set; } 

    }
}
