using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jil;

namespace TinderAPI.Models.AccountData
{
    public enum Blend
    {
        Optimal,
        Recency
    }

    public enum DiscoverableParty
    {
        Everyone,
        Liked
    }

    public class PlusControl
    {
        [JilDirective("blend")]
        public Blend Blend { get; protected set; }
        [JilDirective("discoverable_party")]
        public DiscoverableParty DiscoverableParty { get; protected set; }
        [JilDirective("hide_ads")]
        public bool HideAds { get; protected set; }
        [JilDirective("HideAge")]
        public bool HideAge { get; protected set; }
        [JilDirective("HideDistance")]
        public bool HideDistance { get; protected set; }
    }
}
