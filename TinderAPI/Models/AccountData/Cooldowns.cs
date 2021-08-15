using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jil;

namespace TinderAPI.Models.AccountData
{
    public class Cooldowns
    {
        [JilDirective("likes")]
        public LikeResponse Likes { get; protected set; }

        [JilDirective("super_likes")]
        public SuperLikes SuperLikes { get; protected set; }
    }
}
