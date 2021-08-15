using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jil;

namespace TinderAPI.Models.Recommendations
{
    public class UserInterests
    {
		[JilDirective("max_interests")]
		public int MaxInterests { get; protected set; }

		[JilDirective("min_interests")]
		public int MinInterests { get; protected set; }

		[JilDirective("available_interests")]
		public CommonThing[] AvailableInterests { get; protected set; }

		[JilDirective("selected_interests")]
		public CommonThing[] SelectedInterests { get; protected set; }

	}
}
