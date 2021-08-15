using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinderAPI.Models
{
    public class SelectorModel
    {
        public string content_hash { get; set; }
        public string s_number { get; set; }
        public string top_picks { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public string token { get; set; }
        public string otherUserId { get; set; }
        public string action { get; set; }
    }
}
