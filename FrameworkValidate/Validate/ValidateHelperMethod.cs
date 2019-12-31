using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkValidate.Validate
{
    public static class ValidateHelperMethod
    {
        public static string EmptyStringIfNull(this string value)
        {
            if (value.IsNull())
            {
                return string.Empty;
            }
            else
            {
                return value;
            }
        }

        public static T To<T>(this object value)
        {
            return value.To<T>(default(T));
        }

        public static T To<T>(this object value, T fallback)
        {
            if (value == null)
            {
                return fallback;
            }

            var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(T));
            if (converter != null)
            {
                try
                {
                    return (T)converter.ConvertFromString(value.ToString());
                }
                catch (Exception)
                {
                    return fallback;
                }

            }
            return fallback;
        }

        public static int ToInt(this object value, int fallback = default(int))
        {
            return value.To<int>(fallback);
        }

        public static short ToShort(this object value, short fallback = default(short))
        {
            return value.To<short>(fallback);
        }

        public static long ToLong(this object value, long fallback = default(long))
        {
            return value.To<long>(fallback);
        }

        public static double ToDouble(this object value, double fallback = default(double))
        {
            return value.To<double>(fallback);
        }

        public static decimal ToDecimal(this object value, decimal fallback = default(decimal))
        {
            return value.To<decimal>(fallback);
        }

        public static bool ToBool(this object value, bool fallback = default(bool))
        {
            return value.To<bool>(fallback);
        }
    }
}
