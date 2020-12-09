using System.Linq;
using NAudio.CoreAudioApi;

namespace HudMicSwitch
{
    public static class MicAccess
    {
        public record DeviceSpecs(string FriendlyName, DataFlow DeviceType);

        private static readonly DeviceSpecs _voiceMeeterOutput = new("VoiceMeeter Output (VB-Audio VoiceMeeter VAIO)", DataFlow.Capture);
        private static readonly DeviceSpecs _cableInput = new ("CABLE Input (VB-Audio Virtual Cable)", DataFlow.Render);
        private static readonly DeviceSpecs _cableOutput = new ("CABLE Output (VB-Audio Virtual Cable)", DataFlow.Capture);

        public static void MicOn()
        {
            SetLevel(_voiceMeeterOutput, 100.Percent());
            SetLevel(_cableOutput, 20.Percent());
        }

        public static void MicOff()
        {
            SetLevel(_voiceMeeterOutput, 0.Percent());
            SetLevel(_cableOutput, 100.Percent());
        }

        private static void SetLevel(DeviceSpecs deviceSpecs, float level)
        {
            using var deviceEnumerator = new MMDeviceEnumerator();
            var devices = deviceEnumerator.EnumerateAudioEndPoints(deviceSpecs.DeviceType, DeviceState.Active).ToArray();
            var device = devices.SingleOrDefault(d => d.FriendlyName == deviceSpecs.FriendlyName);
            if (device != null)
            {
                device.AudioEndpointVolume.MasterVolumeLevelScalar = level;
            }
        }
    }
}
