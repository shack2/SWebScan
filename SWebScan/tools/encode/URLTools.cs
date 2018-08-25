using shack2.tools.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace shack2.tools.encode
{
    class URLTools
    {
        public static ServerInfo getHostAndPathQueryByURL(String url){

            try
            {
                ServerInfo server = new ServerInfo();
                Uri uri = new Uri(url);
                server.host = uri.Host;
                server.url = uri.PathAndQuery;
                server.port = uri.Port;
                return server;
            }
            catch (Exception e) {

                throw e;
            }
        }
    }
}
