#nullable enable
using System;
using System.Windows.Forms;
using HudMicSwitch.Lib;

namespace VoiceMeeterTest;

public partial class Form1 : Form
{
    private readonly VoiceMeeterClient _client;

    public Form1()
    {
        InitializeComponent();

        _client = new VoiceMeeterClient(null);
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var key = textBoxKey.Text;
        var value = textBoxValue.Text;
        if (float.TryParse(value, out var valueFloat))
        {
            _client.SetParam(key, valueFloat);
        }
        else
        {
            _client.SetParam(key, value ?? string.Empty);
        }
    }

    private void Form1_Closed(object? sender, EventArgs e)
    {
        _client.Dispose();
    }
}