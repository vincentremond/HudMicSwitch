using System.Runtime.InteropServices;

namespace HudMicSwitch
{
    internal static class VoiceMeeterRemote
    {
        [DllImport(@"C:\Program Files (x86)\VB\VoiceMeeter\VoiceMeeterRemote64.dll", EntryPoint = "VBVMR_Login")]
        public static extern VbLoginResponse Login();

        [DllImport(@"C:\Program Files (x86)\VB\VoiceMeeter\VoiceMeeterRemote64.dll", EntryPoint = "VBVMR_Logout")]
        public static extern VbLoginResponse Logout();

        [DllImport(@"C:\Program Files (x86)\VB\VoiceMeeter\VoiceMeeterRemote64.dll", EntryPoint = "VBVMR_SetParameterFloat")]
        public static extern int SetParameter(string szParamName, float value);

        [DllImport(@"C:\Program Files (x86)\VB\VoiceMeeter\VoiceMeeterRemote64.dll", EntryPoint = "VBVMR_GetParameterFloat")]
        public static extern int GetParameter(string szParamName, ref float value);
    }
}
