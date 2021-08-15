using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jil;
using TinderAPI.Models.AccountData;

namespace TinderAPI.Models
{
    public class SuperLikeResponse
    {
        [JilDirective("limit_exceeded")]
        public bool LimitExceeded { get; protected set; }

        [JilDirective("match")]
        public bool IsMatch { get; protected set; }

        [JilDirective("status")]
        public int Status { get; protected set; }

        [JilDirective("super_likes")]
        public SuperLikes SuperLikes { get; protected set; }
    }
}
