using System;

namespace HudMicSwitch
{
    public class MicAccess : IDisposable
    {
        private readonly VoiceMeterClient _voiceMeterClient;

        public MicAccess()
        {
            _voiceMeterClient = new VoiceMeterClient(null);
        }

        public void MicOn()
        {
            _voiceMeterClient.SetParam("Strip[0].Mute", 0f);
            _voiceMeterClient.SetParam("Strip[1].Mute", 0f);
            _voiceMeterClient.SetParam("Strip[2].Gain", -22.0f);
        }

        public void MicOff()
        {
            _voiceMeterClient.SetParam("Strip[0].Mute", 1f);
            _voiceMeterClient.SetParam("Strip[1].Mute", 1f);
            _voiceMeterClient.SetParam("Strip[2].Gain", 0f);
        }

        public void Dispose() => _voiceMeterClient.Dispose();

        public MicState GetCurrentState()
        {
            var isMuted1 = Convert.ToBoolean(_voiceMeterClient.GetParam("Strip[0].Mute"));
            var isMuted2 = Convert.ToBoolean(_voiceMeterClient.GetParam("Strip[1].Mute"));
            return isMuted1 && isMuted2
                ? MicState.On
                : MicState.Off;
        }
    }

    public enum MicState
    {
        On,
        Off,
    }
}
