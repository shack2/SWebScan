using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace shack2.tools.model
{
    [Serializable]
    public class Config
    {
        public Config() {
        
        }
        public String domain = "";
        public int threadSize = 20;
        public int scanMode = 1;
        public String method = "HEAD";
        public String url = "";
        public int timeOut = 10;//秒
        public Boolean scanWAF = false;
        public Boolean getBanner = false;

        public String ext = "";
        public int sleepTime = 0;//毫秒
        public String request = "";
        public String key = "";
        public String showCodes = "404";
        public int show = 0;
        public int isExists = 0;
        //
        public Boolean getHeaderFirstLine = true;

        public int contentSelect = 0;

        public int contentLength = -2;

        public String contentType="";

    }
}
