using System;
using System.Text;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using shack2.tools.file;
using shack2.tools.model;

namespace shack2.tools
{
    class Tools
    {
        public const String httpLogPath = "logs/http/";

        public static long currentMillis()
        {
            return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
        }
        public static String encodeURIPath(String path)
        {
            return Uri.EscapeUriString(path).Replace("#","%23");
        }
        public static bool ThreadPoolIsEnd()
        {
            int workerThreads = 0;
            int maxWordThreads = 0;
            //int 
            int compleThreads = 0;
            ThreadPool.GetAvailableThreads(out workerThreads, out compleThreads);
            ThreadPool.GetMaxThreads(out maxWordThreads, out compleThreads);

            if (maxWordThreads == workerThreads)
            {
                return true;
            }
            else {
                return false;
            }
        }
       
        public static void SysLog(String log)
        {
            FileTool.AppendLogToFile("logs/" + DateTime.Now.ToLongDateString() + ".log.txt", log + "----" + DateTime.Now);
        }

        public static String fomartTime(String time)
        {
            try
            {
                DateTime dt = Convert.ToDateTime(time);
                String newtime = dt.ToLocalTime().ToString();
                return newtime;
            }
            catch (Exception e)
            {
                SysLog(e.Message);
            }
            return time;

        }

      

        public static void sysHTTPLog(String index ,ServerInfo server)
        {
            FileTool.AppendLogToFile(httpLogPath + index + "-request.txt", server.request);
            FileTool.AppendLogToFile(httpLogPath + index + "-response.txt", server.header + "\r\n\r\n" + server.body);
        }

        public static void delHTTPLog()
        {
            try
            {
                DirectoryInfo din = new DirectoryInfo(httpLogPath);
                FileInfo[] files = din.GetFiles();
                foreach (FileInfo f in files)
                {
                    f.Delete();
                }
            }
            catch (Exception re)
            {
                Tools.SysLog("删除HTTP日志发生错误！" + re.Message);
            }
        }


        public static String convertToString(String[] strs){

            StringBuilder sb = new StringBuilder();
            foreach(String s in strs){
                sb.Append(s);
            }
            return sb.ToString();
        
        }

        /// <summary>
        /// 将字符串转换成数字，错误返回0
        /// </summary>
        /// <param name="strs">字符串</param>
        /// <returns></returns>
        public static int convertToInt(String str)
        {

            try
            {
                return int.Parse(str);
            }
            catch (Exception e) {
                Tools.SysLog("info:-" + e.Message + "----将字符串[" + str + "]转换成数字发生错误----！");
            }
            return 0;

        }
        /// <summary>
        /// 将16进制转换成10进制
        /// </summary>
        /// <param name="str">16进制字符串</param>
        /// <returns></returns>
        public static int convertToIntBy16(String str)
        {
          try
            {
                return Convert.ToInt32(str,16);
            }
            catch (Exception e)
            {
                
            }
            return 0;

        }

        public static Boolean checkEmpty(String str) {

            if (str != null && str.Length > 0)
            {
                return false;
            }
            else {
                return true;
            }
        }

        public static String randIP()
        {
            Random rd = new Random();

            String ip = rd.Next(1, 255) + "." + rd.Next(1, 255) + "." + rd.Next(1, 255) + "." + rd.Next(1, 255);

            return ip;
        }

    
        public static String getCurrentPath(String url)
        {
            int index =url.LastIndexOf("/");

            if (index != -1)
            {
                return url.Substring(0,index)+"/";
            }
            else {
                return "";
            }
        }

        public static String getRootDomain(String domain)
        {
            int index = domain.LastIndexOf(".");

            if (index>0)
            {
                int index2 = domain.LastIndexOf(".", index - 1);
                if (index2 != -1)
                {
                    return domain.Substring(index2+1);
                }
               
            }
            return domain;
        }
        public const String CONTENTLENGTH = "Content-Length: ";
        public static int getLength(String header)
        {

            return Tools.convertToInt(getHeaderInfo(CONTENTLENGTH, header));


        }

        public static String getHeaderInfo(String key, String header)
        {

            int s_index = -1;
            int s_endIndex = -1;
            String server = "";
            try
            {
                if ((s_index = header.IndexOf(key)) != -1)
                {
                    if ((s_endIndex = header.IndexOf("\r", s_index + key.Length)) != -1)
                    {
                        server = header.Substring(s_index + key.Length, s_endIndex - s_index - key.Length).Trim();
                    }
                }
            }
            catch (Exception e)
            {

            }
            return server;
        }
        public  const String SERVER = "Server: ";
        public static String getServerInfo(String header)
        {

            return getHeaderInfo(SERVER, header);
        }
        public  const String ContentType = "Content-Type: ";
        public static String getContentType(String header)
        {
            String contentType = getHeaderInfo(ContentType, header);
            if(!String.IsNullOrEmpty(contentType)){
                int cindex = contentType.IndexOf(";");
                if (cindex != -1) {
                    contentType = contentType.Substring(0, cindex);
                }
            }
            
            return contentType;
        }
        public  const String PowerBy = "X-Powered-By: ";
        public static String getPowerBy(String header)
        {

            return getHeaderInfo(PowerBy, header);
        }

        public const String Location = "Location: ";
        public static String getLocation(String header)
        {

            return getHeaderInfo(Location, header);
        }
       

        //验证并修改域名格式
        public static String updateTheDomain(String weburl,bool delEND)
        {
            if ("".Equals(weburl.Trim()))
            {
                return "";
            }
            if (!weburl.StartsWith("http://")&&!weburl.StartsWith("https://"))
            {
                weburl = "http://" + weburl;
            }
            if (delEND)
            {
                if (weburl.EndsWith("/"))
                {
                    weburl = weburl.Substring(0, weburl.Length - 1);
                }
            }

            return weburl;
        }

        //获取HTTP状态码
        public static int getHttpCode(String headFirstLine)
        {
            int code = 0;
            try
            {
                //查找状态码
                if (!String.IsNullOrEmpty(headFirstLine))
                {
                    code = int.Parse(headFirstLine.Split(' ')[1]);
                }
            }
            catch (Exception e)
            {
                Tools.SysLog("waring:截取HTTP状态码，发生异常！----" + headFirstLine);
            }
            return code;
        }

        public static String getHost(String domain)
        {

            try
            {
                Uri u = new Uri(domain);
                return u.Host;

            }
            catch (Exception e)
            {
            }
            return domain;
        }

        public static String getHostCenter(String host)
        {
            String center = "";
            try
            {

                int s = host.IndexOf(".");
                int e = host.IndexOf(".", s + 1);
                if (e <= s)
                {
                    center = host.Substring(0, s);
                }
                else
                {
                    center = host.Substring(s + 1, e - s - 1);
                }

            }
            catch (Exception e)
            {
            }
            return center.ToLower().Replace("http://", "");
        }

        public static String getIP(String url)
        {
            try
            {
               
                Uri uri = new Uri(url);
                String host = uri.Host;
                bool isIP = Regex.IsMatch(url, @"[\d]{1,3}\.[\d]{1,3}\.[\d]{1,3}\.[\d]{1,3}");
                if (isIP) {
                    return host;
                }
                IPHostEntry hostinfo = Dns.GetHostEntry(host);
                IPAddress[] aryIP = hostinfo.AddressList;

                return aryIP[0].ToString();

            }
            catch (Exception e)
            {
            }
            return "";
        }

        public static String UrlEncode(String str)
        {

          
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9') || c == '-' || c == '.' || c == ':' || c == '(' || c == ')' || c == '*' || c == '_' || c == '!' || c == '/')
                {
                    stringBuilder.Append(c);
                }
                else
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(new char[] { c });
                    byte[] array = bytes;
                    for (int j = 0; j < array.Length; j++)
                    {
                        byte b = array[j];
                        stringBuilder.Append("%");
                        stringBuilder.Append(b.ToString("x2"));
                    }
                }
            }
            return stringBuilder.ToString();
            
           
        }

    }
}
