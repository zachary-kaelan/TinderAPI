using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jil;

namespace TinderAPI.Models.AccountData
{
    class EmailSettings
    {
        [JilDirective("email")]
        public string Email { get; protected set; }
        [JilDirective("email_settings")]
        public Settings Email_Settings { get; protected set; }

        public struct Settings
        {
            [JilDirective("messages")]
            public bool Messages { get; set; }
            [JilDirective("new_matches")]
            public bool NewMatches { get; set; }
            [JilDirective("promotions")]
            public bool Promotions { get; set; }
        }
    }
}
