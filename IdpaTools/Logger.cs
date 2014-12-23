using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IdpaTools
{
    /**
     * Logger
     * Class to Store the Data form the Keylogfile
     * Tobias Bolliner & Thierry Girod
     */
    public class Logger
    {
        public List<ApplicationLog> applicationLog = new List<ApplicationLog>();
    }

    /**
     * ApplcationLog
     * Application List for every Application captior insert Keys
     * Tobias Bolliner & Thierry Girod
     */
    public class ApplicationLog
    {
        public string processName;
        public string windowName;
        public DateTime date;
        public List<string> keyList = new List<string>();
    }
}
