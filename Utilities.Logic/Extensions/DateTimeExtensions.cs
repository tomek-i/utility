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

        public static DateTime Midnight(this DateTime dt)
        {
            return WithTimeMin(dt);
        }
        public static DateTime Midday(this DateTime dt)
        {
            return WithTime(dt, 12, 0, 0, 0);
        }

        public static DateTime WithTime(this DateTime dt, int hour, int minute, int second, int ms=0)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, hour, minute, second, ms);
        }

        public static DateTime WithTimeMax(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999);
        }
        public static DateTime WithTimeMin(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
        }
    }
}