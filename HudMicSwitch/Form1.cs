using System;
using System.Windows.Forms;
using NAudio.CoreAudioApi;

namespace HudMicSwitch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MicAccess.MicOn();
        }

        private void btnBTW_Click(object sender, EventArgs e)
        {
            MicAccess.MicOff();
        }
    }
}
