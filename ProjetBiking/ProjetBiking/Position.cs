using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class Position
    {
        public Position() { }
        public Position(string la, string lg)
        {
            latitude = la;
            longitude = lg;
        }
        public string latitude { get; set; }
        public string longitude { get; set; }
    }
}
