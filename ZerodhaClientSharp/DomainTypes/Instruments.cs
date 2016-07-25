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
            public float last_price { get; set; }
            public string expiry { get; set; }
            public float    strike { get; set; }
            public float tick_size { get; set; }
            public int    lot_size { get; set; }
            public string instrument_type { get; set; }
            public string segment { get; set; }
            public string exchange { get; set; }
        
    }
}
