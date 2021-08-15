using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jil;

namespace TinderAPI.Models
{
    public enum TinderUStatus
    {
        Verified,
        Possible
    }

    public class TinderU
    {
        [JilDirective("school")]
        public VerifiedSchool School { get; protected set; }

        [JilDirective("status")]
        public TinderUStatus Status { get; protected set; }
    }

    public class VerifiedSchool
    {

        [JilDirective("school_id")]
        public string ID { get; protected set; }
        [JilDirective("name")]
        public string Name { get; protected set; }

        [JilDirective("card_name")]
        public string CardName { get; protected set; }

        [JilDirective("primary_color")]
        public string PrimaryColor { get; protected set; }

        [JilDirective("secondary_color")]
        public string SecondaryColor { get; protected set; }

    }
}
