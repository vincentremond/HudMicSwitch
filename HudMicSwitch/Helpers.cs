using System;
using System.Text;
using NativeWifi;

namespace HudMicSwitch
{
    internal static class Helpers
    {
        public static T With<T>(this T obj, Action<T> set)
        {
            set(obj);
            return obj;
        }

        public static string AsString(this Wlan.Dot11Ssid ssid)
        {
            return new string(
                value: Encoding.UTF8.GetChars(ssid.SSID),
                startIndex: 0,
                length: (int)ssid.SSIDLength
            );
        }
    }
}
