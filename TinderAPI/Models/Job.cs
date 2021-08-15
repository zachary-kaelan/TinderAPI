using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jil;

namespace TinderAPI.Models
{
    public class Job
    {
        [JilDirective("company")]
        public DisplayableThing Company { get; protected set; }
        [JilDirective("title")]
        public DisplayableThing Title { get; protected set; }

        public override string ToString() =>
            (Title != null ? Title.Name : "") +
            (Company != null ? (Title != null ? ", " : "") + Company.Name : "");
    }
}
