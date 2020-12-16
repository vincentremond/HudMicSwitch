using CommandLine;

namespace HudMicSwitch
{
    internal class CommandLineOptions
    {
        [Option('w', "wait", Required = false, HelpText = "Seconds to wait before starting", Default = 0)]
        public int SecondsToWait { get; set; }
    }
}
