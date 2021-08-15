using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinderAPI.Models
{
    public class LikeRequest
    {
        public string content_hash { get; set; }
        public string liked_content_id { get; set; }
        public string liked_content_type { get; set; }
        public long s_number { get; set; }
    }
}
