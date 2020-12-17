using System;
using System.Collections.Generic;

namespace HudMicSwitch
{
    internal class MicAccess : IDisposable
    {
        private readonly VoiceMeterClient _voiceMeterClient;
        private readonly Config _config;

        public MicAccess(Config config)
        {
            _config = config;
            _voiceMeterClient = new VoiceMeterClient(null);
        }

        public void MicOn() => SetVariables(_config.On);
        public void MicOff() => SetVariables(_config.Off);

        private void SetVariables(IDictionary<string, string> variables)
        {
            foreach (var (key, value) in variables)
            {
                if (float.TryParse(value, out var floatValue))
                {
                    _voiceMeterClient.SetParam(key, floatValue);
                }
                else
                {
                    _voiceMeterClient.SetParam(key, value);
                }
            }
        }

        public void Dispose() => _voiceMeterClient.Dispose();

        public MicState GetCurrentState()
        {
            foreach (var (name, expected) in _config.CheckIsOff)
            {
                var actualValue = _voiceMeterClient.GetParam(name);
                var expectedValue = float.Parse(expected);
                if (Math.Abs(actualValue - expectedValue) > 0.01f)
                {
                    return MicState.On;
                }
            }

            return MicState.Off;
        }
    }

    internal enum MicState
    {
        On,
        Off,
    }
}
