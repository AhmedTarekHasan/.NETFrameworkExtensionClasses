using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentSimplyPut.ExtensionMethods.IConvertibleEM
{
    public static class IConvertibleExtensionMethods
    {
        public static T ext_ConvertTo<T>(this IConvertible value)
        {
            object holder = Convert.ChangeType(value, typeof(T));
            T result = default(T);

            if (null != holder)
            {
                result = (T)holder;
            }

            return result;
        }
    }
}