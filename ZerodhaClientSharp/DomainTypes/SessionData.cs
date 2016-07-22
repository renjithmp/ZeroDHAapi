using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZerodhaClientSharp.DomainTypes
{
    public class SessionData
    {
        public string access_token { get; set; }
        public string public_token { get; set; }
        public string user_id { get; set; }
        public string user_type { get; set; }
        public string email { get; set; }
        public string user_name { get; set; }
        public string login_time { get; set; }
        public string broker { get; set; }
        public List<string> exchange { get; set; }
        public List<string> product { get; set; }
        public List<string> order_type { get; set; }
    }
}
