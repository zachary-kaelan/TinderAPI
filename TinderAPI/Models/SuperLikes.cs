using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jil;

namespace TinderAPI.Models
{
    public class SuperLikes
	{
		[JilDirective("remaining")]
		public int Remaining { get; private set; }

		[JilDirective("alc_remaining")]
		public int AllocationRemaining { get; private set; }

		[JilDirective("new_alc_remaining")]
		public int NewAllocationRemaining { get; private set; }

		[JilDirective("allotment")]
		public int Allotment { get; private set; }

		[JilDirective("superlike_refresh_amount")]
		public int SuperlikeRefreshAmount { get; private set; }

		[JilDirective("superlike_refresh_interval")]
		public int SuperlikeRefreshInterval { get; private set; }

		[JilDirective("superlike_refresh_interval_unit")]
		public string SuperlikeRefreshIntervalUnit { get; private set; }

		[JilDirective("resets_at")]
		public DateTime ResetsAt { get; private set; }

	}
}
