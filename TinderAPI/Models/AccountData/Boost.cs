using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jil;

namespace TinderAPI.Models.AccountData
{
    public class Boost
    {
        [JilDirective("allotment")]
        public int Allotment { get; protected set; }
        [JilDirective("allotment_remaining")]
        public int AllotmentRemaining { get; protected set; }
        [JilDirective("allotment_used")]
        public int AllotmentUsed { get; protected set; }

        [JilDirective("boost_ended")]
        public bool Ended { get; protected set; }
        [JilDirective("boost_id")]
        public string ID { get; protected set; }
        [JilDirective("boost_refresh_amount")]
        public int RefreshAmount { get; protected set; }
        [JilDirective("boost_refresh_interval")]
        public int RefreshInterval { get; protected set; }
        [JilDirective("boost_refresh_interval_unit")]
        public char RefreshIntervalUnit { get; protected set; }

        [JilDirective("duration")]
        public int DurationMS { get; protected set; }
        [JilDirective("internal_remaining")]
        public int InternalRemaining { get; protected set; }
        [JilDirective("multiplier")]
        public double Multiplier { get; protected set; }
        [JilDirective("purchased_remaining")]
        public int PurchasedRemaining { get; protected set; }
        [JilDirective("purchases")]
        public string[] Purchases { get; protected set; }
        [JilDirective("remaining")]
        public int Remaining { get; protected set; }

        [JilDirective("resets_at")]
        public long ResetsAt { get; protected set; }
        [JilDirective("result_viewed_at")]
        public long ResultViewedAt { get; protected set; }
    }
}
