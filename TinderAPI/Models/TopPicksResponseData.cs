using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jil;

namespace TinderAPI.Models
{
    public class TopPicksResponseData
    {
        [JilDirective("count")]
        public int Count { get; protected set; }

        [JilDirective("free_likes_remaining")]
        public int FreeLikesRemaining { get; protected set; }

        [JilDirective("next_page_token")]
        public string NextPageToken { get; protected set; }

        [JilDirective("results")]
        public Recommendations.Recommendation[] Results { get; protected set; }

        [JilDirective("top_picks_available")]
        public bool TopPicksAvailable { get; protected set; }

        [JilDirective("top_picks_end")]
        public bool TopPicksEnd { get; protected set; }

        [JilDirective("top_picks_refresh_time")]
        public long TopPicksRefreshTime { get; protected set; }
    }

    public class TopPicksRateResponseData
    {
        [JilDirective("free_likes_remaining")]
        public int FreeLikesRemaining { get; protected set; }

        [JilDirective("exhausted")]
        public string Exhausted { get; protected set; }

        [JilDirective("uid")]
        public string UserID { get; protected set; }

        [JilDirective("response")]
        public object Response { get; protected set; }
    }
}
