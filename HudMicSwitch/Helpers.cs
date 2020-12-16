using System;

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
