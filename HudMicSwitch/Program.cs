using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace HudMicSwitch
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                KillOtherInstances();
                using var micAccess = new MicAccess();
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1(micAccess));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), @"Error", MessageBoxButtons.OK);
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
