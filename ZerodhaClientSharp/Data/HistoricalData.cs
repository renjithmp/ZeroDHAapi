using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZerodhaClientSharp.Client;
using ZerodhaClientSharp.DomainTypes;

namespace ZerodhaClientSharp.Data
{
    public class HistoricData
    {
        public HistoricDataWrapper GetHistoricData(string api_key,string user_token,string timeStampFrom,string timeStampTo,string intervalType,string instrumentId)
        {
            //"https://api.kite.trade/instruments/historical/5633/minute?from=2015-12-28&to=2016-01-01&api_key=xxx&access_token=yyy"

                 var request = new  RestRequest("instruments/historical/{instrument_id}/{interval_id}?from={timestamp_from}&to={timestamp_to}&api_key={api_key}&access_token={user_token}", Method.GET);
                 request.AddParameter("instrument_id", instrumentId, ParameterType.UrlSegment);
                 request.AddParameter("interval_id", intervalType, ParameterType.UrlSegment);
                 request.AddParameter("timestamp_from", timeStampFrom, ParameterType.QueryString);
                 request.AddParameter("timestamp_to", timeStampTo, ParameterType.QueryString);
                 request.AddParameter("api_key", api_key, ParameterType.QueryString);
                 request.AddParameter("user_token", user_token, ParameterType.QueryString);
                 var response = ZerodhaClient.GetClient().Client.Execute<HistoricDataWrapper>(request);
                 return response.Data;
                      

        }

        public void TopGainers()
        {


        }

        public void CandidateStocks()
        {


        }
        public void FutureInstrumentList(string stockExchangeCode)
        {


        }
       
    }
}
