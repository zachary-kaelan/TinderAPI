using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jil;

namespace TinderAPI.Models.Recommendations
{
    public enum TeaserType
    {
        Artists,
        Instagram,
        JobPosition,
        School
    }

    public class Teaser
    {
        [JilDirective("string")]
        public string Text { get; protected set; }
        [JilDirective("type")]
        public string Type { get; protected set; }

        public override string ToString() => Text;
    }
}
