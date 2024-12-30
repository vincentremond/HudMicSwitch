namespace HudMicSwitch.Lib;

internal enum VbLoginResponse
{
    Ok = 0,
    OkVoiceMeeterNotRunning = 1,
    NoClient = -1,
    AlreadyLoggedIn = -2,
}
