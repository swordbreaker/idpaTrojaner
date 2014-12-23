using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace IdpaClient
{
    static class Serilizer
    {
        public static void writeDataToFile(string path, Logger logger)
        {
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(logger.GetType());
                x.Serialize(sw, logger);
                Debug.WriteLine(logger);
            }
        }

        public static Logger getDataFromFile(string path, Logger logger)
        {
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(logger.GetType());
                    logger = (Logger)x.Deserialize(sr);
                    return logger;
                }
            }
            return logger = new Logger();
        }
    }
}
