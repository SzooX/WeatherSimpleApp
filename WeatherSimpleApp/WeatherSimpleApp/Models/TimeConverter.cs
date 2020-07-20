using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherSimpleApp.Models
{
    public class TimeConverter
    {
        /// <summary>
        /// Convert Unix time value to a DateTime object.
        /// </summary>
        /// <param name="unixtime">The Unix time stamp you want to convert to DateTime.</param>
        /// <returns>Returns a DateTime object that represents value of the Unix time.</returns>
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp, string ZoneName)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById(ZoneName);
            dtDateTime.AddHours(tzi.BaseUtcOffset.Hours );
            return dtDateTime;
        }
    }
}
