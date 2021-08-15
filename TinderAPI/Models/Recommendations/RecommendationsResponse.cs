using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Jil;

namespace TinderAPI.Models.Recommendations
{
    public class RecommendationsResponse
    {
        [JilDirective("results")]
        public Recommendation[] Results { get; protected set; }

        [JilDirective("page_token")]
        public string PageToken { get; protected set; }
    }
}
