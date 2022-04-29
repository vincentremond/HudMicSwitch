using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NHotkey;
using NHotkey.WindowsForms;

namespace HudMicSwitch
{
    internal sealed partial class Form1 : Form
    {
        private MicState _currentState;
        private readonly MicAccess _micAccess;
        private readonly Timer _blinkTimer;

        // Hide from alt-tab
        protected override CreateParams CreateParams => base.CreateParams.With(createParams => createParams.ExStyle |= 0x80);

        public Form1(MicAccess micAccess, Config config)
        {
            _micAccess = micAccess;
            TopMost = true;
            BackColor = Color.White;
            TransparencyKey = Color.White;
            InitializeComponent();
            (StartPosition, Location) = GetPosition(Width);
            _blinkTimer = new Timer
            {
                Interval = 1000,
                Enabled = false,
            };
            _blinkTimer.Tick += BlinkTimerOnTick;

            HotkeyManager.Current.AddOrReplace($"ToggleMute", config.ToggleMuteHotkey.GetHotKey(), noRepeat: true, ToggleMute);
            
            config.AutoConfigs.ForEach((autoConfig, index) =>
            {
                var mapping = (
                    from l in autoConfig.Locations
                    let locationId = l.Key
                    let wifiSsids = l.Value
                    from w in wifiSsids
                    let wifiSsid = (string)(w ?? string.Empty)
                    select (wifiSsid, locationId)
                ).ToDictionary();
                HotkeyManager.Current.AddOrReplace($"ResetConfig{index}", autoConfig.HotKey.GetHotKey(), noRepeat: true, (o, args) => ResetConfig(mapping));
            });
            
            SetCurrentState(_micAccess.GetCurrentState());
        }

        private void BlinkTimerOnTick(object? sender, EventArgs e) => label1.BackColor = Invert(label1.BackColor, Color.Red, Color.Yellow);

        private static Color Invert(in Color currentColor, in Color aColor, in Color bColor) => currentColor == aColor ? bColor : aColor;

        private (FormStartPosition StartPosition, Point Location) GetPosition(int width)
        {
            var primaryScreenWorkingArea = Screen.PrimaryScreen.WorkingArea;
            var x = (primaryScreenWorkingArea.Width / 2) - (width / 2);
            var y = primaryScreenWorkingArea.Y;
            return (FormStartPosition.Manual, new Point(x: x, y));
        }

        private void SetCurrentState(MicState currentState)
        {
            _currentState = currentState;
            (Action UpdateAction, string Emoji, Color Color, int Height) update = currentState switch
            {
                MicState.On => (SetMicOn, "🎤", Color.Red, 40),
                MicState.Off => (SetMicOff, "", Color.Gray, 5),
                _ => throw new ArgumentOutOfRangeException(nameof(currentState), currentState, null)
            };
            update.UpdateAction();
            label1.Text = update.Emoji;
            label1.ForeColor = Color.Black;
            label1.BackColor = update.Color;
            label1.Height = update.Height;
        }

        private void SetMicOn()
        {
            _blinkTimer.Enabled = true;
            _micAccess.MicOn();
        }

        private void SetMicOff()
        {
            _blinkTimer.Enabled = false;
            _micAccess.MicOff();
        }

        private void ToggleMute(object? _, HotkeyEventArgs __) => ToggleMute();

        private void ResetConfig(IReadOnlyDictionary<string, string> autoConfigLocations)
        {
            _micAccess.ResetConfig(autoConfigLocations);
            MessageBox.Show(@"Configuration has been reset", @"Config reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ToggleMute() => SetCurrentState(Invert(_currentState));

        private MicState Invert(MicState currentState) =>
            currentState switch
            {
                MicState.On => MicState.Off,
                MicState.Off => MicState.On,
                _ => throw new ArgumentOutOfRangeException(nameof(currentState), currentState, null)
            };

        private void label1_Click(object _, MouseEventArgs eventArgs) =>
            ((Action)(eventArgs.Button switch
            {
                MouseButtons.Left => ToggleMute,
                MouseButtons.Right => Close,
                _ => Noop
            }))();

        private static void Noop()
        {
        }
    }
}
