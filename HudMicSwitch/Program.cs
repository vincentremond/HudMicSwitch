using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using CommandLine;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HudMicSwitch
{
    static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            Parser.Default.ParseArguments<CommandLineOptions>(args).WithParsed(RealMain);
        }

        private static void RealMain(CommandLineOptions options)
        {
            try
            {
                var config = ReadConfig("Config.json") ?? throw new Exception("Failed to read configuration");

                WaitSomeTime(options.SecondsToWait);
                KillOtherInstances();
                using var micAccess = new MicAccess(config);
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1(micAccess, config));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), @"Error", MessageBoxButtons.OK);
            }
        }

        private static Config? ReadConfig(string configJson)
        {
            var contents = File.ReadAllText(configJson);
            var jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.Converters.Add(new StringEnumConverter()); 
            var config = JsonConvert.DeserializeObject<Config>(contents, jsonSerializerSettings);
            return config;
        }

        private static void WaitSomeTime(in int secondsToWait)
        {
            if (secondsToWait > 0)
            {
                Thread.Sleep(TimeSpan.FromSeconds(secondsToWait));
            }
        }

        private static void KillOtherInstances()
        {
            var currentProcess = Process.GetCurrentProcess();
            Process
                .GetProcesses()
                .Where(p => p.ProcessName == currentProcess.ProcessName)
                .Where(p => p.Id != currentProcess.Id)
                .ToList()
                .ForEach(p => p.Kill());
        }
    }
}
