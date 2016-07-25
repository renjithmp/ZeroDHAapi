using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ZerodhaClientSharp.Data;
using ZerodhaClientSharp.ZWebSocket;

namespace Future_BTST.Controllers
{
    public class HomeController : ZerodhaController
    {
        public void Index()
        {
            ViewBag.Title = "Home Page";

            var redirectUri = ZClient.ZLogin.SiteLogin();
            HttpContext.Response.Redirect(redirectUri);

        }
        [Route("Home/zerodha_response")]
        public string zerodha_response(string status, string request_token)
        {
            var response = ZClient.ZLogin.GetUserToken(request_token);
            HttpContext.Session["UserToken"] = response ?? "Default";
            return response;
        }

public List<Instrument>  TestMe(bool test=true)
        {
            InstrumentData instrumentList = new InstrumentData();
           var list= instrumentList.GetUnderlyingForFUT("aw230frvr95ajkzx", "NFO","NSE", "FUT","EQ",TimeSpan.FromDays(30));
           return list;
        }

        public List<FullTick> GetTopGainers(string p1,string p2,string p3)
{
    List<Instrument> ins = TestMe(true);
    MarketMovement move = new MarketMovement();
  var topG=   move.TopGainers(10, ins.Select(x => x.instrument_token).ToList());
  return topG;
}

    }
}
