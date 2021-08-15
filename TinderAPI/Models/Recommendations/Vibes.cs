using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jil;

namespace TinderAPI.Models.Recommendations
{
    public class Vibes
    {
        [JilDirective("prompts")]
        public VibePrompt[] Prompts { get; set; }

        [JilDirective("round")]
        public int Round { get; set; }
    }
}
