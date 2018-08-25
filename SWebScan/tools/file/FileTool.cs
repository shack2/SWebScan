using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace shack2.tools.file
{
    class FileTool
    {
        public static List<string> readAllDic(String dic)
        {
            List<string> fs = new List<string>();
            try
            {
                DirectoryInfo din = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory+"/"+dic);
                FileInfo[] files = din.GetFiles();
                foreach (FileInfo f in files)
                {
                    fs.Add(f.Name);
                }
            }
            catch (Exception re)
            {
                Tools.SysLog(dic + "读取错误！" + re.Message);
            }
            return fs;
        }
        public static List<String> readFileToList(String path)
        {
            
            List<String> list = new List<String>();
            FileStream fs_dir = null;
            StreamReader reader = null;
            try
            {
                fs_dir = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "/" + path, FileMode.Open, FileAccess.Read);

                reader = new StreamReader(fs_dir);

                String lineStr;

                while ((lineStr = reader.ReadLine()) != null)
                {
                    if (!lineStr.Equals(""))
                    {
                       list.Add(lineStr);
                    }
                }
            } catch (Exception e)
            {
                Tools.SysLog(e.Message);
            }
            finally {
                if (reader != null)
                {
                    reader.Close();
                }
                if (fs_dir != null)
                {
                    fs_dir.Close();
                }
            }
            return list;
        }

        public static List<String> readFileToListByEncoding(String path,String encode)
        {

            List<String> list = new List<String>();
            FileStream fs_dir = null;
            StreamReader reader = null;
            try
            {
                fs_dir = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "/" + path, FileMode.Open, FileAccess.Read);
                
                reader = new StreamReader(fs_dir,Encoding.GetEncoding(encode));

                String lineStr;

                while ((lineStr = reader.ReadLine()) != null)
                {
                    if (!lineStr.Equals(""))
                    {
                        int index = 0;
                        if ((index = lineStr.IndexOf("?")) != -1)
                        {
                            String cpath = lineStr.Substring(0, index);
                            String data = lineStr.Substring(index+1, lineStr.Length - index-1);
                            list.Add(Tools.encodeURIPath(Tools.UrlEncode(cpath) + "?" + data));
                        }
                        else {
                            list.Add(Tools.UrlEncode(lineStr));
                        }
                        
                    }

                }
            }
            catch (Exception e)
            {
                Tools.SysLog(e.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (fs_dir != null)
                {
                    fs_dir.Close();
                }
            }
            return list;
        }
        public static int getReadFileLine(String path)
        {

           
            FileStream fs_dir = null;
            StreamReader reader = null;
            int line = 0;
            try
            {
                fs_dir = new FileStream(path, FileMode.Open, FileAccess.Read);

                reader = new StreamReader(fs_dir);

                String lineStr;
                
                while ((lineStr = reader.ReadLine()) != null)
                {
                    line++;
                }
                
            }
            catch (Exception e)
            {
                Tools.SysLog(e.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (fs_dir != null)
                {
                    fs_dir.Close();
                }
            }
            return line;
        }
        public static List<String> readDomainToList(String path)
        {

            List<String> list = new List<String>();
            FileStream fs_dir = null;
            StreamReader reader = null;
            try
            {
                fs_dir = new FileStream(path, FileMode.Open, FileAccess.Read);

                reader = new StreamReader(fs_dir);

                String lineStr;

                while ((lineStr = reader.ReadLine()) != null)
                {
                    if (!lineStr.Equals("")&&!lineStr.StartsWith("http")) {
                        lineStr = "http://" + lineStr;
                    }
                    list.Add(lineStr);
                }
            }
            catch (Exception e)
            {
                Tools.SysLog(e.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (fs_dir != null)
                {
                    fs_dir.Close();
                }
            }
            return list;
        }

        //读取文件
        public static String readFileToString(String path)
        {
            String str = "";
            FileStream fs_dir=null;
            StreamReader reader = null;
            try
            {
                fs_dir = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "/" + path, FileMode.Open, FileAccess.Read);
                reader = new StreamReader(fs_dir);
                str = reader.ReadToEnd();
            }
            catch (Exception e)
            {
                Tools.SysLog("readFileToString发生异常！"+e.Message);
            }finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (fs_dir != null)
                {
                    fs_dir.Close();
                }
            }
            return str;
            
        }
        //读取文件
        public static Byte[] readFileToByte(String path,int a)
        {
            Byte[] buffer = null;
            FileStream fs_dir=null;
            StreamReader reader = null;
            try
            {
                fs_dir = new FileStream(path, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs_dir);
                int len = (int)fs_dir.Length;

                buffer = new byte[len];

                int size = br.Read(buffer, 0, len);

                reader.Read();
                
            }
            catch (Exception e)
            {
                Tools.SysLog("readFileToByte-error:读取文件内容发生错误！"+e.Message);
            }finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (fs_dir != null)
                {
                    fs_dir.Close();
                }
            }
            return buffer;
            
        }
        public static object c = "";
        public static void AppendLogToFile(String path,String log)
        {
            //锁住，防止多线程引发错误
            lock (c)
            {
                List<String> list = new List<String>();
                FileStream fs_dir = null;
                StreamWriter sw = null;
                try
                {
                    fs_dir = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "/" + path, FileMode.Append, FileAccess.Write);

                    sw = new StreamWriter(fs_dir);

                    sw.WriteLine(log);

                    sw.Close();

                    fs_dir.Close();

                }
                catch (Exception e)
                {
                    Tools.SysLog("FileTools-AppendLogToFile-error:读取文件内容发生错误！"+e.Message);
                }
                finally
                {
                    if (sw != null)
                    {
                        sw.Close();
                    }
                    if (fs_dir != null)
                    {
                        fs_dir.Close();
                    }
                }
            }

        }
    }
}
