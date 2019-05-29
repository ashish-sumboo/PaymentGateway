using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public static class GenericExtensions
    {
        public static void GuardForNull<T>(this T param, string paramName)
        {
            if (param == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }
    }
}
