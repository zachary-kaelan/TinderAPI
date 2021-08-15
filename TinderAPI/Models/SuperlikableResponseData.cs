using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jil;

namespace TinderAPI.Models
{
    public class SuperlikableResponseData
    {
        [JilDirective("position")]
        public int Position { get; protected set; }
        [JilDirective("results")]
        public Recommendations.Recommendation[] Results { get; protected set; }
        [JilDirective("timestamp")]
        public ulong Timestamp { get; protected set; }
        [JilDirective("token")]
        public string Token { get; protected set; }
        [JilDirective("ttlSeconds")]
        public int TTLSeconds { get; protected set; }
    }
}
