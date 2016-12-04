using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Telldus_API_wrapper.Models
{
    public class TelldusDevice
    {
        public string client { get; set; } // = 160628
        public string clientDeviceId { get; set; } // = 4
        public string clientName { get; set; } // = Leilighet
        public int editable { get; set; } // = 1
        public string id { get; set; } // = 838820
        public int ignored { get; set; } // = 0
        public int methods { get; set; } // = 3
        public string name { get; set; } // = Leilighet - Stue - Varmovn
        public string online { get; set; } // = 1
        public int state { get; set; } // = 2
        public string statevalue { get; set; } // = unde
        public string type { get; set; } // = device
    }
}