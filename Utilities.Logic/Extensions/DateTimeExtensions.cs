using System;

namespace TI.Utilities.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime LastYear(this DateTime dt)
        {
            return dt.AddYears(-1);
        }
        public static DateTime LastMonth(this DateTime dt)
        {
            return dt.AddMonths(-1);
        }
        public static DateTime LastWeek(this DateTime dt)
        {
            return dt.AddDays(-7);
        }
        public static DateTime LastDay(this DateTime dt)
        {
            return dt.AddDays(-1);
        }

        public static DateTime NextYear(this DateTime dt)
        {
            return dt.AddYears(1);
        }
        public static DateTime NextMonth(this DateTime dt)
        {
            return dt.AddMonths(1);
        }
        public static DateTime NextWeek(this DateTime dt)
        {
            return dt.AddDays(7);
        }
        public static DateTime NextDay(this DateTime dt)
        {
            return dt.AddDays(1);
        }
    }
}