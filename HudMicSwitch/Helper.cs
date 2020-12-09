using System;

namespace HudMicSwitch
{
    public static class Helper
    {
        public static float Percent(this int value)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            return 0.01f * value;
        }
    }
}
