using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

             Task.Factory.StartNew(() => StartEngine(engine));

          while(true)
          {
              if (zSubscriber.ProcessedAPacket)
                  break;
              Thread.Sleep(1000);
          }
            List<ResponsePackage<FullTick>> response = zSubscriber.Response;
            return response;    
        }

        private void StartEngine(WebSocketEngine engine)
        {
            engine.Run("", "", "");
        }
    }
}
