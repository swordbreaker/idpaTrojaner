using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IdpaClient
{
    public class Logger
    {
        public List<ApplicationLog> applicationLog = new List<ApplicationLog>();
    }

    public class ApplicationLog
    {
        public string applicationName;
        public DateTime date;
        public List<string> keyList = new List<string>();
    }
}
