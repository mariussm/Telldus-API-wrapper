using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Telldus_API_wrapper.Models
{
    public class TelldusSensor
    {
        public int battery { get; set; } // = 254
        public string client { get; set; } // = 160628
        public string clientName { get; set; } // = Leilighet
        public int editable { get; set; } // = 1
        public string id { get; set; } // = 4049354
        public int ignored { get; set; } // = 0
        public int keepHistory { get; set; } // = 0
        public int lastUpdated { get; set; } // = 1480412064
        public string model { get; set; } // = temperature
        public string name { get; set; } // = Leiligcet - Ute(sensor - 3)
        public string online { get; set; } // = 1
        public string protocol { get; set; } // = fineoffset
        public string sensorId { get; set; } // = 136
        public List<TelldusSensorData> data { get; set; }
    }
}