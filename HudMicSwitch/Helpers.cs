using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HudMicSwitch
{
    internal static class Helpers
    {
        public static T With<T>(this T obj, Action<T> set)
        {
            set(obj);
            return obj;
        }
    }
}
