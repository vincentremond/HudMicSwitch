using System.Collections.Generic;
using System.Windows.Forms;

namespace HudMicSwitch
{
    internal record Config(
        Keys[][] ToggleMuteHotkeys,
        Keys[][] ResetConfigHotkeys,
        IReadOnlyDictionary<string, string> Reset,
        IReadOnlyDictionary<string, string> On,
        IReadOnlyDictionary<string, string> Off,
        IReadOnlyDictionary<string, string> CheckIsOff
    );
}
