using System;
using System.Collections.Generic;
using System.Linq;
using HudMicSwitch.Lib;
using NativeWifi;

namespace HudMicSwitch
{
    internal class MicAccess : IDisposable
    {
        private readonly VoiceMeeterClient _voiceMeeterClient;
        private readonly Config _config;

        public MicAccess(Config config)
        {
            _config = config;
            _voiceMeeterClient = new VoiceMeeterClient(null);
        }

        public void MicOn() => SetVariables(_config.On);
        public void MicOff() => SetVariables(_config.Off);

        private void SetVariables(IReadOnlyDictionary<string, string> variables)
        {
            foreach (var (key, value) in variables)
            {
                if (float.TryParse(value, out var floatValue))
                {
                    _voiceMeeterClient.SetParam(key, floatValue);
                }
                else
                {
                    _voiceMeeterClient.SetParam(key, value);
                }
            }
        }

        public void Dispose() => _voiceMeeterClient.Dispose();

        public MicState GetCurrentState()
        {
            foreach (var (name, expected) in _config.CheckIsOff)
            {
                var actualValue = _voiceMeeterClient.GetParam(name);
                var expectedValue = float.Parse(expected);
                if (Math.Abs(actualValue - expectedValue) > 0.01f)
                {
                    return MicState.On;
                }
            }

            return MicState.Off;
        }

        public void ResetConfig()
        {
            var currentWifiSsid = GetCurrentWifiSsid();
            var resetConfigByWifi =
                _config.Reset.FirstOrDefault(r => r.Wifi.Contains(currentWifiSsid))?.Setup
                ?? throw new InvalidOperationException();

            SetVariables(resetConfigByWifi);
        }

        private string? GetCurrentWifiSsid()
        {
            var wlanInterface = new WlanClient()
                .Interfaces?
                .FirstOrDefault(w => w.InterfaceState == Wlan.WlanInterfaceState.Connected);

            return wlanInterface?.CurrentConnection.wlanAssociationAttributes.dot11Ssid.AsString();
        }
    }

    internal enum MicState
    {
        On,
        Off,
    }
}
