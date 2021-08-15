using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinderAPI.Models
{
    public class FacebookToken
    {
        public string facebook_token { get; set; }
        public string facebook_id { get; set; }
    }

    public class SMSRefresh
    {
        public string refresh_token { get; set; }
        public string phone_number { get; set; }
    }
}
