using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jil;

namespace TinderAPI.Models
{
    public class CommonThing
    {
        [JilDirective("is_common")]
        public bool IsCommon { get; protected set; }

        [JilDirective("name")]
        public string Name { get; protected set; }

        [JilDirective("id")]
        public string ID { get; protected set; }

        public override string ToString() => Name;
    }
}
