using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jil;
using TinderAPI.Models;

namespace TinderAPI.Models.Recommendations
{
    public enum RecInteraction
    {
        Pass,
        Like,
        Super
    }

    public class RecUserProfile : BaseProfile
    {
        [JilDirective("is_traveling")]
        public bool IsTraveling { get; protected set; }
        //public uint s_number { get; protected set; }
    }
}
