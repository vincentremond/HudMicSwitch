using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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

        internal static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection)
            {
                action(item);
            }
        }

        internal static void ForEach<T>(this IEnumerable<T> collection, Action<T, int> action)
        {
            collection.Select((item, index) => (item, index)).ForEach(x => action(x.item, x.index));
        }

        internal static Keys GetHotKey(this IEnumerable<Keys> keys)
        {
            return keys.Aggregate(Keys.None, (keys1, keys2) => keys1 | keys2);
        }

        internal static IReadOnlyDictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<(TKey, TValue)> enumerable) where TKey : notnull
        {
            var dictionary = enumerable.ToDictionary(i => i.Item1, i => i.Item2);
            return new ReadOnlyDictionary<TKey, TValue>(dictionary);
        }

        internal static TValue? GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
            => dictionary.TryGetValue(key, out var value) ? value : default;

        internal static IReadOnlyDictionary<TKey, TValue> MergeWith<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary1, IReadOnlyDictionary<TKey, TValue> dictionary2) where TKey : notnull
        {
            return dictionary1.Keys.Concat(dictionary2.Keys).Distinct().Select(k => (k,
                dictionary2.TryGetValue(k, out var value2) ? value2
                : dictionary1.TryGetValue(k, out var value1) ? value1
                : throw new InvalidOperationException())
            ).ToDictionary();
        }
    }
}
