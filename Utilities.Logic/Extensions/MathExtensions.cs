using System.Linq;

namespace TI.Utilities.Extensions
{

    public static class MathExtensions
    {
        ////TODO: need to use compare to and the result value of -1 0 +1
        //public static bool Between<T>(this T number, T lower, T upper, bool inclusive) where T:struct,IComparable,IFormattable,IConvertible,IComparable<T>,IEquatable<T>
        //{

        //    if (inclusive)
        //    {
        //        return number <= upper && number >= lower;
        //    }
        //    else
        //    {
        //        return number < upper && number > lower;
        //    }
        //}
        public static bool Between(this int number, int lower, int upper, bool inclusive)
        {

            if (inclusive)
            {
                return number <= upper && number >= lower;
            }
            else
            {
                return number < upper && number > lower;
            }
        }
        public static bool Between(this long number, long lower, long upper, bool inclusive)
        {

            if (inclusive)
            {
                return number <= upper && number >= lower;
            }
            else
            {
                return number < upper && number > lower;
            }
        }
        public static bool Between(this byte number, byte lower, byte upper, bool inclusive)
        {

            if (inclusive)
            {
                return number <= upper && number >= lower;
            }
            else
            {
                return number < upper && number > lower;
            }
        }
        public static bool Between(this short number, short lower, short upper, bool inclusive)
        {

            if (inclusive)
            {
                return number <= upper && number >= lower;
            }
            else
            {
                return number < upper && number > lower;
            }
        }
        public static bool Between(this uint number, uint lower, uint upper, bool inclusive)
        {

            if (inclusive)
            {
                return number <= upper && number >= lower;
            }
            else
            {
                return number < upper && number > lower;
            }
        }
        public static bool Between(this ulong number, ulong lower, ulong upper, bool inclusive)
        {

            if (inclusive)
            {
                return number <= upper && number >= lower;
            }
            else
            {
                return number < upper && number > lower;
            }
        }
        public static bool Between(this char number, char lower, char upper, bool inclusive)
        {

            if (inclusive)
            {
                return number <= upper && number >= lower;
            }
            else
            {
                return number < upper && number > lower;
            }
        }
        public static bool Between(this sbyte number, sbyte lower, sbyte upper, bool inclusive)
        {

            if (inclusive)
            {
                return number <= upper && number >= lower;
            }
            else
            {
                return number < upper && number > lower;
            }
        }
        public static bool Between(this ushort number, ushort lower, ushort upper, bool inclusive)
        {

            if (inclusive)
            {
                return number <= upper && number >= lower;
            }
            else
            {
                return number < upper && number > lower;
            }
        }
        public static bool Between(this double number, double lower, double upper, bool inclusive)
        {

            if (inclusive)
            {
                return number <= upper && number >= lower;
            }
            else
            {
                return number < upper && number > lower;
            }
        }
        public static bool Between(this decimal number, decimal lower, decimal upper, bool inclusive)
        {

            if (inclusive)
            {
                return number <= upper && number >= lower;
            }
            else
            {
                return number < upper && number > lower;
            }
        }
        public static bool Between(this float number, float lower, float upper, bool inclusive)
        {

            if (inclusive)
            {
                return number <= upper && number >= lower;
            }
            else
            {
                return number < upper && number > lower;
            }
        }
        
        public static bool IsEither(this int number, params int[] values)
        {
            return values.Any(v=>number == v);
        }
        public static bool IsEither(this long number, params long[] values)
        {
            return values.Any(v => number == v);
        }
        public static bool IsEither(this byte number, params byte[] values)
        {
            return values.Any(v => number == v);
        }
        public static bool IsEither(this short number, params short[] values)
        {
            return values.Any(v => number == v);
        }
        public static bool IsEither(this uint number, params uint[] values)
        {
            return values.Any(v => number == v);
        }
        public static bool IsEither(this ulong number, params ulong[] values)
        {
            return values.Any(v => number == v);
        }
        public static bool IsEither(this char number, params char[] values)
        {
            return values.Any(v => number == v);
        }
        public static bool IsEither(this sbyte number, params sbyte[] values)
        {
            return values.Any(v => number == v);
        }
        public static bool IsEither(this ushort number, params ushort[] values)
        {
            return values.Any(v => number == v);
        }
        public static bool IsEither(this double number, params double[] values)
        {
            return values.Any(v => number == v);
        }
        public static bool IsEither(this decimal number, params decimal[] values)
        {
            return values.Any(v => number == v);
        }
        public static bool IsEither(this float number, params float[] values)
        {
            return values.Any(v => number == v);
        }

    }
}