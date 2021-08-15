using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jil;

namespace TinderAPI.Models
{
    public class BumperSticker
    {
		[JilDirective("enabled")]
		public bool Enabled { get; protected set; }

		[JilDirective("id")]
		public string ID { get; protected set; }

		[JilDirective("url")]
		public string URL { get; protected set; }

		[JilDirective("ttl")]
		public int TTL { get; protected set; }

	}
}
