using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinderAPI
{
    internal static class Utils
    {

        public static readonly DateTime UNIX_START_DATE = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        public static long ToUnixTimestamp(this DateTime dateTime, bool milliseconds = false) =>
            milliseconds ?
                Convert.ToInt64((dateTime.ToUniversalTime() - UNIX_START_DATE).TotalMilliseconds) :
                Convert.ToInt64((dateTime.ToUniversalTime() - UNIX_START_DATE).TotalSeconds);

        public static DateTime ConvertUnixTimestamp(long timestamp)
        {
            return timestamp > 1000000000000 ?
                UNIX_START_DATE.AddMilliseconds(timestamp).ToLocalTime() :
                UNIX_START_DATE.AddSeconds(timestamp).ToLocalTime();
        }
    }
}
