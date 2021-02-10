using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace BasicServerHTTPlistener
{
    class Header
    {
        private NameValueCollection header;
        public Header(HttpListenerRequest h)
        {
            this.header = h.Headers;
        }
        public String displayHeader()
        {
            {
                string html = "<br/>";
                for (int i = 0; i < this.header.Count; i++)
                {
                    html += " Cle : " + this.header.GetKey(i) + " : " + " Valeur : " + this.header.Get(i) + "<br/>";
                }
                return html;
            }
        }
    }
}
