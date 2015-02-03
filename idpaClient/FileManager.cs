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
        private static Form1 activeForm = (System.Windows.Forms.Application.OpenForms["Form1"] as Form1);

        public static void SaveLogFile(byte[] data, string savePath)
        {
            File.WriteAllBytes(savePath, data);
            activeForm.print("Log file saved under: " + savePath);
        }

        public static void SaveZipFile(byte[] data, string savePath)
        {
            File.WriteAllBytes(savePath, data);
            activeForm.print("Zip file saved under: " + savePath);
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
