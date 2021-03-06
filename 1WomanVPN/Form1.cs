using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace _1WomanVPN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }   

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "1Woman Server" && radioButton1.Checked)
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.FileName = @"C:\Program Files\OpenVPN\bin\openvpn.exe";
                startInfo.Arguments = "--config ukudp.ovpn";
                startInfo.Verb = "runas";
                process.StartInfo = startInfo;
                process.Start();
                MessageBox.Show("You have connected to 1Woman server using UDP");
            }
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.FileName = @"C:\Program Files\OpenVPN\bin\openvpn.exe";
                startInfo.Arguments = "--config uktcp.ovpn";
                startInfo.Verb = "runas";
                process.StartInfo = startInfo;
                process.Start();
                MessageBox.Show("You have connected to 1Woman server using TCP");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            disconnect();

            MessageBox.Show($"Warning! This server will disconnect");

            string title = "1Women VPN";
            string message = "Do you want to disconnect this server?";

            MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);

            if (result == DialogResult.No)
            {
                this.Close();
            }
            else
            if (result == DialogResult.Yes)
            {

            }
        }


        //When button is pressed, it will kill openVPN.exe so that we disconnect from the VPN
        private void disconnect()
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "taskkill",
                CreateNoWindow = true,
                UseShellExecute = false
            }).WaitForExit();

        }



        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
