using System;

namespace TI.Utilities.Extensions
{

    public static class TimeSpanExtensions
    {

        public static double ToDouble(this TimeSpan time)
        {
            return Math.Round(time.TotalHours, 2, MidpointRounding.AwayFromZero);
        }
        public static double ToDouble(this TimeSpan time, int digits, MidpointRounding rounding)
        {
            //decimal minutes = Math.ROund((1.0m/(60/time.Minutes)),2,MidpointRounding.AwayFromZero);
            return Math.Round(time.TotalHours, digits, rounding);
        }
    }
}