using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jil;

namespace TinderAPI.Models.Recommendations
{
    public class VibeTeaser : Teaser
    {
        [JilDirective("response_id")]
        public string ResponseID { get; set; }

        [JilDirective("sub_string")]
        public string SubText { get; set; }
    }
}
