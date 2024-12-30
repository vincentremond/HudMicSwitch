using System;
using Microsoft.Extensions.Logging;

namespace HudMicSwitch.Lib;

public class VoiceMeeterClient : IDisposable
{
    private readonly ILogger<VoiceMeeterClient>? _logger;

    public VoiceMeeterClient(ILogger<VoiceMeeterClient>? logger)
    {
        _logger = logger;
        Login();
    }

    private void Login()
    {
        Logout();
        var loginResponse = VoiceMeeterRemote.Login();

        var info = loginResponse switch
        {
            VbLoginResponse.Ok => "Attached.",
            VbLoginResponse.OkVoiceMeeterNotRunning => "Attached but VoiceMeeter is not running.",
            VbLoginResponse.AlreadyLoggedIn => "Attached. Was already logged in",
            VbLoginResponse.NoClient => "No client",
            _ => throw new InvalidOperationException($"Bad response from VoiceMeeter: {loginResponse}"),
        };
        _logger?.LogInformation(info);
    }

    public void SetParam(string n, float v)
    {
        VoiceMeeterRemote.SetParameter(n, v);
    }

    public void SetParam(string n, string v)
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
        Logout();
    }

    private void Logout()
    {
        var logoutResponse = VoiceMeeterRemote.Logout();
        _logger?.LogInformation($"Logged out {logoutResponse}");
    }
}