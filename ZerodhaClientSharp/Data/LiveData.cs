using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZerodhaClientSharp.ZWebSocket;

namespace ZerodhaClientSharp.Data
{
    public class LiveData
    {
        public List<ResponsePackage<FullTick>> GetDataForInstruments(List<int> instrument)
        {
            ZSocketSubscriber<FullTick> zSubscriber = new ZSocketSubscriber<FullTick>();
            zSubscriber.instruments = instrument;
            zSubscriber.action=RequestAction.subscribe;            
            WebSocketEngine engine = new WebSocketEngine();
            engine.Subscriber = zSubscriber;
            engine.Run("", "", "");
            List<ResponsePackage<FullTick>> response = zSubscriber.Response;
            return response;    
        }
    }
}
