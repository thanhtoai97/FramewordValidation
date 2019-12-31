using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkValidate.Validate
{
    public static class ValidateType
    {
        // Use : value.Is<T>()
        public static bool Is<T>(this object value)
        {
            if (value == null)
            {
                return false;
            }

            var converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(T));

            try
            {
                T result = (T)converter.ConvertFromString(value.ToString());
                return result != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsInt(this object value)
        {
            return value.Is<int>();
        }

        public static bool IsShort(this object value)
        {
            return value.Is<short>();
        }

        public static bool IsLong(this object value)
        {
            return value.Is<long>();
        }

        public static bool IsDouble(this object value)
        {
            return value.Is<Double>();
        }

        public static bool IsDecimal(this object value)
        {
            return value.Is<Decimal>();
        }

        public static bool IsBool(this object value)
        {
            return value.Is<bool>();
        }

        public static bool IsNumber(this object value)
        {
            return
                value.IsLong() ||
                value.IsDouble() ||
                value.IsDecimal() ||
                value.IsDouble();
        }
    }
}
