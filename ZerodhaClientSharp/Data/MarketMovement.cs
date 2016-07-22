using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZerodhaClientSharp.ZWebSocket;

namespace ZerodhaClientSharp.Data
{
    class MarketMovement
    {

        public List<FullTick> TopGainers(int count,List<string> instruments)
        {
            LiveData data = new LiveData();
            var marketData=data.GetDataForInstruments(instruments);
             
                marketData.Sort( (x,y) => Convert.ToInt32(((x.Response.Last_traded_price - x.Response.Close_price)/x.Response.Close_price - (y.Response.Last_traded_price - y.Response.Close_price)/y.Response.Close_price))) ;

                return marketData.Take(count).Select(x => x.Response).ToList();
         
        }


        public List<FullTick> TopLosers(int count, List<string> instruments)
        {
            LiveData data = new LiveData();
            var marketData = data.GetDataForInstruments(instruments);

            marketData.Sort((x, y) => -Convert.ToInt32(((x.Response.Last_traded_price - x.Response.Close_price) / x.Response.Close_price - (y.Response.Last_traded_price - y.Response.Close_price) / y.Response.Close_price)));

            return marketData.Take(count).Select(x => x.Response).ToList();

        }

        public List<FullTick> TopVolumeGainers(int count, List<string> instruments)
        {
            LiveData data = new LiveData();
            var marketData = data.GetDataForInstruments(instruments);
            marketData.OrderBy(x => x.Response.Volume_traded).Reverse();                                       
            return marketData.Take(count).Select(x => x.Response).ToList();

        }

        public List<FullTick> TopGainersWithVolumeBreakOut(int minLookupCount, int maxLookUpCount, List<string> instruments,int expectedMinNumberOfResults)
        { 
            int resultCount = 0;
            int count=minLookupCount;
            int stepUp=10;
            List<FullTick> combined=null;
            while(resultCount < expectedMinNumberOfResults && count <=maxLookUpCount )
            { 
             List<FullTick> volumneBreakers = TopVolumeGainers(count, instruments);
             List<FullTick> topGainers = TopGainers(count, instruments);
            combined= volumneBreakers.Intersect(topGainers, new FullTickComparer()).ToList();
            if (combined.Count < expectedMinNumberOfResults)
            {
                resultCount = combined.Count;
                count += stepUp;
            }
            else
                break;
            }
            return combined;
        }
    }
}
