using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jil;

namespace TinderAPI.Models
{
    public struct FacebookData
    {
        [JilDirective("common_connections")]
        public int CommonConnections { get; set; }
        [JilDirective("common_interests")]
        public int CommonInterests { get; set; }
        [JilDirective("connection_count")]
        public int ConnectionCount { get; set; }
    }

    public class Facebook
    {
        [JilDirective("common_connections")]
        public CommonThing[] CommonConnections { get; protected set; }
        [JilDirective("common_interests")]
        public CommonThing[] CommonInterests { get; protected set; }
        [JilDirective("connection_count")]
        public int ConnectionCount { get; protected set; }
    }
}
