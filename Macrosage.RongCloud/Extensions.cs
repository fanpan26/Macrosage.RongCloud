using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macrosage.RongCloud
{
    internal static class Extensions
    {
        private static readonly IRestRequest request = new RestRequest();
        public static long ToTimestamp(this DateTime time)
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return (long)(time - startTime).TotalSeconds;
        }

        public static string ToJson(this object value)
        {
            return request.JsonSerializer.Serialize(value);
        }
    }
}
