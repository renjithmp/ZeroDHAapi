using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZerodhaClientSharp.Data;
using ZerodhaClientSharp.DomainTypes;
using ZerodhaClientSharp.LoginData;
namespace ZerodhaClientSharp.Client
{
    public class ZerodhaClient
    {
       
        public RestClient Client { get; set; }
        public static ZerodhaClient zerodhaClient;
        private ZerodhaClient()
        {
            Client = new RestClient("https://api.kite.trade");
        }
        public static ZerodhaClient GetClient()
        {
            if (zerodhaClient == null)
                return new ZerodhaClient();
            else
               return zerodhaClient;
        }

        public Login  ZLogin{ get{return new Login();} }

        public HistoricData ZHistoricData { get { return new HistoricData(); } }


    }
}
