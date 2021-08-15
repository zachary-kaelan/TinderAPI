using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jil;

namespace TinderAPI.Models.Recommendations
{
    public class VibePrompt
    {
        [JilDirective("is_mutual")]
        public bool IsMutual { get; set; }

        [JilDirective("prompt")]
        public string Prompt { get; set; }

        [JilDirective("response")]
        public string Response { get; set; }

        [JilDirective("response_id")]
        public string ResponseID { get; set; }
    }
}
