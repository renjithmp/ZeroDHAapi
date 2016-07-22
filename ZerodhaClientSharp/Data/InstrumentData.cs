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
    public class InstrumentData
    {

        public List<Instrument> GetInstrumentsForInstrumentType(string api_key, string exchange, string instrument_type, TimeSpan? maturity = null)
        {

            var request = new RestRequest("instruments?api_key={api_key}", Method.GET);
            request.AddParameter("api_key", api_key, ParameterType.QueryString);
            var response = ZerodhaClient.GetClient().Client.Execute(request);
            var respArray = from x in response.Content.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Skip(1)
                            let columns = x.Split(',')
                            select new Instrument
                            {
                                instrument_token = Convert.ToInt32(columns[0]),
                                exchange_token = Convert.ToInt32(columns[1]),
                                tradingsymbol = columns[2],
                                name = columns[3],
                                last_price = Convert.ToDouble(columns[4]),
                                expiry = columns[5],
                                strike = Convert.ToDouble(columns[6]),
                                tick_size = Convert.ToDouble(columns[7]),
                                lot_size = Convert.ToInt32(columns[8]),
                                instrument_type = columns[9],
                                segment = columns[10],
                                exchange = columns[11]
                            };
            var instruments = respArray.Where(x =>
                {
                    if (x.exchange == exchange && x.instrument_type == instrument_type)
                    {
                        if (maturity != null)
                        {
                            var TimeSpan = DateTime.Parse(x.expiry) - DateTime.Now;
                            if (TimeSpan <= maturity)
                            {
                                return true;
                            }
                            else
                                return false;
                        }
                        else
                            return true;
                    }
                    else
                        return false;
                }).ToList();
            return instruments;
        }

        public List<Instrument> GetUnderlyingForFUT(string api_key, string exchange_Fut, string exchange_EQ, string instrument_Type, string underlying_Type, TimeSpan? maturity = null)
        {

            var futuresList = GetInstrumentsForInstrumentType(api_key, exchange_Fut, instrument_Type, maturity);
            var eqList = GetInstrumentsForInstrumentType(api_key, exchange_EQ, underlying_Type, null);
            var underLying = eqList.FindAll(x => futuresList.Find(y => y.tradingsymbol.StartsWith(x.tradingsymbol))!=null).Distinct().ToList();
            return underLying;

        }
    }
}
