using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace idpaServer
{
    /**
     * Serilizer
     * Tool for Serialize the KeyLogger to a xml file
     * Tobias Bolliner & Thierry Girod
     */
    static class Serilizer
    {
        public static void writeDataToFile(string path, Logger logger)
        {
            //Create a StreamWritter
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                //Create a new XmlSerializer and Write the data to the File
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(logger.GetType());
                x.Serialize(sw, logger);
            }
        }

        public static Logger getDataFromFile(string path, Logger logger)
        {
            //Check if the File exists
            if (File.Exists(path))
            {
                //Create a StreamWritter
                using (StreamReader sr = new StreamReader(path))
                {
                    //Create a new XmlSerializer and store the Data form the XML file in the Logger Class
                    System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(logger.GetType());
                    logger = (Logger)x.Deserialize(sr);
                    return logger;
                }
            }
            //When there is no Logfile then return a Empty Logger Class
            return logger = new Logger();
        }
    }
}
