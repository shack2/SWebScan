using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Forms;
using shack2.tools.model;

namespace shack2.tools
{
    class XML
    {
       

        public static void saveConfig(String fileName,Config config)
        {
            Stream fStream = null;
            try
            {
                fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                //创建XML序列化器，需要指定对象的类型
                XmlSerializer xmlFormat = new XmlSerializer(typeof(Config));
                xmlFormat.Serialize(fStream, config);
                fStream.Close();

            }
            catch (Exception e)
            {

                throw e;
            }
            finally {
            if(fStream!=null){
                fStream.Close();
            }
            
            }
        }

        public static Config readConfig(String configPath)
        {
            Stream fStream = null;
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(Config));
                //创建XML序列化器，需要指定对象的类型
                fStream = new FileStream(configPath, FileMode.Open, FileAccess.Read);
                XmlTextReader reader = new XmlTextReader(fStream);
                reader.Normalization = false;
                Config config = (Config)xml.Deserialize(reader);
                return config;
            }
            catch (Exception e)
            {

                throw e;
            }
            finally {
                if (fStream != null) {

                    fStream.Close();
                }
            }
        }
    }
}
