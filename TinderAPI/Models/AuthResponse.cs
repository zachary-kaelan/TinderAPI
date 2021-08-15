using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinderAPI.Models
{
    public struct AuthResponse
    {
        public string api_token { get; set; }
        public bool is_new_user { get; set; }
        public string refresh_token { get; set; }
    }
}
