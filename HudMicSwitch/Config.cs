using System.Collections.Generic;
using System.Windows.Forms;

namespace HudMicSwitch
{
    internal record Config(
        IReadOnlyCollection<IReadOnlyCollection<Keys>> ToggleMuteHotkeys,
        IReadOnlyCollection<IReadOnlyCollection<Keys>> ResetConfigHotkeys,
        IReadOnlyCollection<LocationConfiguration> Reset,
        IReadOnlyDictionary<string, string> On,
        IReadOnlyDictionary<string, string> Off,
        IReadOnlyDictionary<string, string> CheckIsOff
    );

    internal record LocationConfiguration(
        IReadOnlyCollection<string?> Wifi,
        IReadOnlyDictionary<string, string> Setup
    );
}
