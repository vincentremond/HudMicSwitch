using System;

namespace HudMicSwitch
{
    public static class Helpers
    {
        public static T With<T>(this T obj, Action<T> set)
        {
            set(obj);
            return obj;
        }
        
    }
}
