using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
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
