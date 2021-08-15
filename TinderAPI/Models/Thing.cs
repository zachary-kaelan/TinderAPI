using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jil;

namespace TinderAPI.Models
{
    public class Thing
    {
        [JilDirective("id")]
        public string ID { get; protected set; }
        [JilDirective("name")]
        public string Name { get; protected set; }

        public override string ToString() => Name;
    }
}
