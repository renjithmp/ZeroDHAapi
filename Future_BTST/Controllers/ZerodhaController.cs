﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using ZerodhaClientSharp.Client;

namespace Future_BTST.Controllers
{
    public class ZerodhaController : ApiController
    {
        protected ZerodhaClient ZClient { get { return ZerodhaClient.GetClient(); } }
    }
}
