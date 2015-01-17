using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdpaClient
{
    class FileManager
    {
        public static void SaveLogFile(string data, string savePath)
        {
            File.WriteAllText(savePath, data);
        }

        public static void CreateFile(string path)
        {
            File.Create(path);
        }

        public static PcInfromations DeserializePcInformations(string xml, PcInfromations pcInformations)
        {
            using (StringReader sr = new StringReader(xml))
            {
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(pcInformations.GetType());
                pcInformations = (PcInfromations)x.Deserialize(sr);
            }

            return pcInformations;
        }
    }
}
