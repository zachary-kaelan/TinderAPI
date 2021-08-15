using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jil;

namespace TinderAPI.Models
{
    public class DisplayableThing : Thing
    {
        [JilDirective("type")]
        public string Type { get; protected set; }
        /*[JilDirective("displayed")]
        public bool Displayed { get; protected set; }*/
    }
}
