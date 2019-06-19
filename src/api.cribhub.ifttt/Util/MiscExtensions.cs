using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.cribhub.ifttt.Util
{
    public static class MiscExtensions
    {
        public static bool IsIfTTTTestMode(this HttpRequest req)
        {
            if (req == null)
                return false;

            if (req.Headers == null)
                return false;

            string testMode = req.Headers["IFTTT-Test-Mode"];

            return "1".Equals(testMode, StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsRealtime(this HttpRequest req)
        {
            if (req == null)
                return false;

            if (req.Headers == null)
                return false;

            string testMode = req.Headers["X-IFTTT-Realtime"];

            return "1".Equals(testMode, StringComparison.OrdinalIgnoreCase);
        }

        public static long ToUnixTime(this DateTime dt)
        {
            return (long)((dt - DateTime.UnixEpoch).TotalSeconds);
        }
    }
}
