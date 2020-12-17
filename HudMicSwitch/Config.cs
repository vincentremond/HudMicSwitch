using System.Collections.Generic;

namespace HudMicSwitch
{
    internal record Config(
        IReadOnlyDictionary<string, string> Reset,
        IReadOnlyDictionary<string, string> On,
        IReadOnlyDictionary<string, string> Off,
        IReadOnlyDictionary<string, string> CheckIsOff
    );
}
