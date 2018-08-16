using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace shack2.tools.model
{
    public class ServerInfo
    {
        public String target = "";//扫描目标
        public String host = "";//host主机头
        public String url = "";//pathAndQuery
        public String path = "";//host主机头
        public int port = 80;
        public String request = "";
        public String server = "";
        public String header = "";
        public String body = "";
        public String reuqestHeader = "";
        public Dictionary<String, String> headers = new Dictionary<String, String>();
        public String response = "";
        public String gzip = "";
        public String encoding = "";
        public String contentType = "";
        public long id = 0;
        public long length = 0;
        public String ip = "";
        public String type = "";
        public int code = 0;
        public int mode = 0;
        public String location = "";
        public long runTime = 0;//获取网页消耗时间，毫秒
        public int sleepTime = 0;//休息时间
        public String powerBy = "";
        public Boolean timeout = false;

    }
}
