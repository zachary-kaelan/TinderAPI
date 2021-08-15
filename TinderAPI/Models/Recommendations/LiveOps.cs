using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jil;

namespace TinderAPI.Models.Recommendations
{
    public class LiveOps
    {
        [JilDirective("teaser")]
        public VibeTeaser Teaser { get; set; }

        [JilDirective("vibes")]
        public Vibes[] Vibes { get; set; }
    }
}
