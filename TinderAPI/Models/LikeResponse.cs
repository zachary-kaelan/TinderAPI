using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jil;

namespace TinderAPI.Models
{
    public class LikeResponse
    {
        [JilDirective("likes_remaining")]
        public int LikesRemaining { get; protected set; }

        [JilDirective("match")]
        public bool IsMatch { get; protected set; }

        [JilDirective("rate_limited_until")]
        public long? RateLimitedUntil { get; protected set; }

        [JilDirective("status")]
        public int Status { get; protected set; }
    }
}
