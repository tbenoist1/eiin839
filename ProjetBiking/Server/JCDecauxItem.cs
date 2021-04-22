using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    // Cet item regroupe toute les informations d'une station JCDecaux
    public class JCDecauxItem
    {
        public JCDecauxItem() { }
        public int number { get; set; }
        public string contractName { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public Position position { get; set; }
        public bool banking { get; set; }
        public bool bonus { get; set; }
        public string status { get; set; }
        public string lastUpdate { get; set; }
        public bool connected { get; set; }
        public bool overflow { get; set; }
        public string shape { get; set; }
        public Stand totalStands { get; set; }
        public Stand mainStands { get; set; }
        public string overflowStands { get; set; }
    }
    public class Stand
    {
        public Stand() { }
        public Availability availabilities { get; set; }
        public int capacity { get; set; }
    }
    public class Availability
    {
        public Availability() { }
        public int bikes { get; set; }
        public int stands { get; set; }
        public int mechanicalBikes { get; set; }
        public int electricalBikes { get; set; }
        public int electricalInternalBatteryBikes { get; set; }
        public int electricalRemovableBatteryBikes { get; set; }
    }
    public class Position
    {
        public Position() { }
        public Position(double la, double lg)
        {
            latitude = la;
            longitude = lg;
        }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
}