using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZerodhaClientSharp.Data
{
    public class Instrument
    {       public int    instrument_token { get; set; }
            public int    exchange_token { get; set; }
            public string tradingsymbol { get; set; }
            public string name { get; set; }
            public double last_price { get; set; }
            public string expiry { get; set; }
            public double    strike { get; set; }
            public double tick_size { get; set; }
            public int    lot_size { get; set; }
            public string instrument_type { get; set; }
            public string segment { get; set; }
            public string exchange { get; set; }
        
    }
}
