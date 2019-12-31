using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkValidate.Validate
{
    public static class ValidateObject
    {
        public static bool IsNotNull(this object value)
        {
            return (value != null);
        }

        public static bool IsNull(this object value)
        {
            return !value.IsNotNull();
        }

        public static bool Is(this object value, Func<bool> func)
        {
            return func();
        }

        public static bool IsNot(this object value, Func<bool> func)
        {
            return !func();
        }
    }
}
