using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZerodhaClientSharp.DomainTypes
{
    public class HistoricDataWrapper
    {
        public string status { get; set; }
        public TradeData data { get; set; }
    }
}
