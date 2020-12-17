using System.Collections.Generic;

namespace HudMicSwitch
{
    internal class Config
    {
        public IDictionary<string, string> Check { get; set; }
        public IDictionary<string, string> On { get; set; }
        public IDictionary<string, string> Off { get; set; }
        public IDictionary<string, string> CheckIsOff { get; set; }
    }
}
