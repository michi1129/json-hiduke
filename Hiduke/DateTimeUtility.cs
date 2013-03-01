using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hiduke
{
    public static class DateTimeUtility
    {
        public static long DateTimeToUnixTime(DateTime dt)
        {
            DateTime d1 = new DateTime(1970, 1, 1);
            DateTime d2 = dt.ToUniversalTime();
            TimeSpan ts = new TimeSpan(d2.Ticks - d1.Ticks);
            return (long)Math.Round(ts.TotalMilliseconds, 0);
        }

        public static DateTime JsonFormatToDateTime(string s)
        {
            string pattern = @"\/Date\((-?\d+)\)\/";
            System.Text.RegularExpressions.Match match = System.Text.RegularExpressions.Regex.Match(s, pattern);
            return match.Groups[1].ToString().UnixTimeToDateTime();
        }

        public static DateTime UnixTimeToDateTime(this string s)
        {
            long l = long.Parse(s);
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(l).ToLocalTime();
        }
    }
}
