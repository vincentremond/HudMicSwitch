using System.Collections.Generic;
using System.Windows.Forms;

namespace HudMicSwitch;

internal record Config(
    IReadOnlyCollection<Keys> ToggleMuteHotkey,
    IReadOnlyCollection<AutoConfig> AutoConfigs,
    IReadOnlyDictionary<string, string> Defaults,
    IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>> Configurations,
    IReadOnlyDictionary<string, string> On,
    IReadOnlyDictionary<string, string> Off,
    IReadOnlyDictionary<string, string> CheckIsOff
);

internal record AutoConfig(
    IReadOnlyCollection<Keys> HotKey,
    IReadOnlyDictionary<string, IReadOnlyCollection<string?>> Locations
);