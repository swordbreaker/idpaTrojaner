using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdpaClient
{
    public class PcInfromations
    {
        public List<Pc> pc = new List<Pc>();
    }

    public class Pc
    {
        public int id;
        public string ip;
        public string name;
        public string winVers;
        public string time;
    }
}
