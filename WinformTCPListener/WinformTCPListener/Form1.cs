using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;
using System.Net.Security;
using System;

namespace WinformTCPListener
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }
        public async Task SendData()
        {
            //8080 for MainShip, 8081 for OBSGL
            Server server = new Server("127.0.0.1", new int[] { 8080,8081 });
            await server.StartAsync();
        }
       
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            SendData();
        }
    }

}