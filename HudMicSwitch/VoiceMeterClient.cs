using System;
using Microsoft.Extensions.Logging;
using VoiceMeeterWrapper;

namespace HudMicSwitch
{
    public class VoiceMeterClient : IDisposable
    {
        private readonly ILogger<VoiceMeterClient> _logger;

        public VoiceMeterClient(ILogger<VoiceMeterClient> logger)
        {
            _logger = logger;
            Login();
        }

        private void Login()
        {
            var loginResponse = VoiceMeeterRemote.Login();

            var info = loginResponse switch
            {
                VbLoginResponse.OK => "Attached.",
                VbLoginResponse.AlreadyLoggedIn => "Attached. Was already logged in",
                _ => throw new InvalidOperationException("Bad response from VoiceMeeter: " + loginResponse),
            };
            _logger?.LogInformation(info);
        }

        public void SetParam(string n, float v)
        {
            VoiceMeeterRemote.SetParameter(n, v);
        }

        public float GetParam(string n)
        {
            float output = -1;
            VoiceMeeterRemote.GetParameter(n, ref output);
            return output;
        }

        public void Dispose()
        {
            VoiceMeeterRemote.Logout();
        }
    }
}
