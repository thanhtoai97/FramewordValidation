using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkValidate.Validate
{
    public static class ValidateString
    {
        #region " Nullable, Empty & Whitespace "
        public static bool IsNotNullOrEmpty(this string value)
        {
            return !string.IsNullOrEmpty(value);
        }

        public static bool IsNullOrEmpty(this string value)
        {
            return !value.IsNotNullOrEmpty();
        }

        public static bool IsNotNullOrWhiteSpace(this string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        public static bool IsNullOrWhiteSpace(this string value)
        {
            return !value.IsNotNullOrWhiteSpace();
        }

        #endregion

        #region " Lengths "
        public static bool IsBetweenLength(this string value, int min, int max)
        {
            if (value.IsNull() && min == 0)
            {
                return true; // if it's null it has length 0
            }
            else if (value.IsNull())
            {
                return false;
            }
            else
            {
                return value.Length >= min && value.Length <= max;
            }
        }

        public static bool IsMaxLength(this string value, int max)
        {
            if (value.IsNull())
            {
                return true; // if it's null it has length 0 and that has to be less than max
            }
            else
            {
                return value.Length <= max;
            }
        }

        public static bool IsMinLength(this string value, int min)
        {
            if (value.IsNull() && min == 0)
            {
                return true; // if it's null it has length 0
            }
            else if (value.IsNull())
            {
                return false;
            }
            else
            {
                return value.Length >= min;
            }
        }

        public static bool IsExactLength(this string value, int length)
        {
            return value.IsBetweenLength(length, length);
        }

        #endregion

        #region " Compare "

        public static bool IsEqualTo(this string value, string compare)
        {
            if (value.IsNull() && compare.IsNull())
            {
                return true;
            }
            if (value.IsNull() || compare.IsNull())
            {
                return false;
            }
            return String.Equals(value, compare, StringComparison.Ordinal);
        }

        #endregion
    }
}
