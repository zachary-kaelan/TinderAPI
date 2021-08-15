using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jil;

namespace TinderAPI.Models.Recommendations
{
    public class ExperimentInfo
    {
        [JilDirective("user_interests")]
        public UserInterests UserInterests { get; protected set; }
    }
}
