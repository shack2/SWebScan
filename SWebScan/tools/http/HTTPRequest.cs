
using shack2.tools.model;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace shack2.tools.http
{
    class HTTPRequest
    {

        public static String getHTMLEncoding(String contenType, String body)
        {
            if (String.IsNullOrEmpty(contenType) && String.IsNullOrEmpty(body))
            {
                return "";
            }
            body = body.ToUpper();

            String encode = "";
            Match m = Regex.Match(contenType, @"charset=(?<charset>[\w\-]+)", RegexOptions.IgnoreCase);
            if (m.Success)
            {
                encode = m.Groups["charset"].Value.ToUpper();
            }
            else
            {
                if (String.IsNullOrEmpty(body))
                {
                    return "";
                }
                m = Regex.Match(body, @"charset=['""]{0,1}(?<charset>[\w\-]+)['""]{0,1}", RegexOptions.IgnoreCase);
                if (m.Success)
                {
                    encode = m.Groups["charset"].Value.ToUpper();
                }
            }
            if ("UTF8".Equals(encode))
            {
                encode = "UTF-8";
            }
            return encode;


        }

        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受     
        }

        public static ServerInfo SendRequestGetHeader(String method,String url,int timeout,bool keepAlive)
        {
            Stopwatch st = new Stopwatch();
            st.Start();
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            ServerInfo res = new ServerInfo();
            Stream rs = null;
            StreamReader sr = null;
            try
            {
                //设置模拟http访问参数
                Uri uri = new Uri(url);
                request = (HttpWebRequest)WebRequest.Create(uri);
                request.Accept = "*/*";
                request.UserAgent = "Mozilla/5.0 (compatible; Baiduspider-render/2.0; +http://www.baidu.com/search/spider.html)";
                request.Method = method;
                request.KeepAlive = keepAlive;
                request.Timeout = timeout*1000;
                request.Headers.Add("X-Forwarded-For", Tools.randIP());
                request.Referer = "http://www.baidu.com/";
                request.AllowAutoRedirect = false;
                request.ServicePoint.Expect100Continue = false;
                request.ServicePoint.UseNagleAlgorithm = false;
                request.ServicePoint.ConnectionLimit = 1024;
                request.AllowWriteStreamBuffering = false;
                request.Proxy = null;

                if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);

                }
                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                    
                }
                catch (WebException e)
                {
                    response = (HttpWebResponse)e.Response;
                }
                
                res.contentType= response.ContentType;
                res.powerBy = response.Headers["X-Powered-By"];
                res.location= response.Headers["Location"];
                res.length = response.ContentLength;
                res.code = (int)(response.StatusCode);
                res.server = response.Server;
            }
            catch (WebException e)
            {
                Tools.SysLog("发生异常：" + e.Message);
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
                if (rs != null)
                {
                    rs.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
            }
            st.Stop();
            res.runTime = st.ElapsedMilliseconds;
            return res;
        }

        public static ServerInfo SendRequestGetBody(String method, String url, int timeout,bool keeAlive)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            ServerInfo res = new ServerInfo();
            Stream rs = null;
            StreamReader sr = null;
            try
            {
                //设置模拟http访问参数
                Uri uri = new Uri(url);
                request = (HttpWebRequest)WebRequest.Create(uri);
                request.Accept = "*/*";
                request.UserAgent = "Mozilla/5.0 (compatible; Baiduspider-render/2.0; +http://www.baidu.com/search/spider.html)";
                request.KeepAlive = keeAlive;
                request.Timeout = timeout * 1000;
                request.Headers.Add("X-Forwarded-For", Tools.randIP());
                request.Referer = "http://www.baidu.com/";
                request.AllowAutoRedirect = false;
                request.ServicePoint.Expect100Continue = false;
                request.ServicePoint.UseNagleAlgorithm = false;
                request.ServicePoint.ConnectionLimit = 1024;
                request.AllowWriteStreamBuffering = false;
                request.Proxy = null;

                if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);

                }
                try
                {
                    response = (HttpWebResponse)request.GetResponse();

                }
                catch (WebException e)
                {
                    response = (HttpWebResponse)e.Response;
                }
                res.contentType = response.ContentType;
                res.powerBy = response.Headers["powerby"];
                res.location = response.Headers["location"];
                res.length = response.ContentLength;
                res.code = (int)(response.StatusCode);
                res.server = response.Server;     
                rs = response.GetResponseStream();
                sr = new StreamReader(rs, Encoding.GetEncoding("UTF-8"));
                res.body = sr.ReadToEnd();
                String encoding = getHTMLEncoding(response.ContentType, res.body);

                if (!"".Equals(encoding) && !"UTF-8".Equals(encoding, StringComparison.OrdinalIgnoreCase)) {
                    rs = response.GetResponseStream();
                    sr = new StreamReader(rs, Encoding.GetEncoding(encoding));
                    res.body = sr.ReadToEnd();
                } ;

            }
            catch (Exception e)
            {
                Tools.SysLog("发生异常：" + e.Message);
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
                if (rs != null)
                {
                    rs.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
            }
            return res;
        }

        public static String getHTML(String url,int timeout){
            String html = "";
            HttpWebResponse response = null;
            StreamReader sr = null;
            HttpWebRequest request = null;
            try
            {

                //设置模拟http访问参数
                Uri uri = new Uri(url);
                request = (HttpWebRequest)WebRequest.Create(uri);
                request.Accept = "*/*";
                request.Method = "GET";
                request.Timeout = timeout*1000;
                request.AllowAutoRedirect = false;
                response = (HttpWebResponse)request.GetResponse();

                Stream s=response.GetResponseStream();
               

                //读取服务器端返回的消息 
                String encode = getHTMLEncoding(response.Headers["Content-Type"],"");
                if (!String.IsNullOrEmpty(encode))
                {
                    sr = new StreamReader(s, Encoding.GetEncoding(encode));
                    html = sr.ReadToEnd();
                }
                else {
                    sr = new StreamReader(s, Encoding.UTF8);
                    html = sr.ReadToEnd();
                }
                s.Close();
                sr.Close();
            }
            catch (Exception e)
            {
                Tools.SysLog(e.Message);
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
                if (request != null)
                {
                    request.Abort();
                }
            }
            return html;
        }
    }
}
