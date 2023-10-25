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
        int udpFlag = 0;
        int tcpFlag = 0;
        public Form1()
        {
            InitializeComponent();
        }
        public async Task SendDataTCP()
        {
            //8080 for MainShip, 8081 for OBSGL
            TcpServer server = new TcpServer("127.0.0.1", new int[] { 8080, 8081 });
            await server.StartAsync();
        }
        public async Task SendDataUDP() 
        {
            string serverIp = "192.168.10.198";
            List<int> ports = new List<int> { 8080, 8081 }; // List of ports to communicate with
            Thread clientThread = new Thread(() =>
            {
                Parallel.ForEach(ports, port =>
                {
                    UdpServer client = new UdpServer(serverIp, port);
                    client.StartAsync($"Hello form {port}! \r\n").Wait();
                });
            });
            clientThread.Start();
            
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (tcpFlag == 1)
            {
                SendDataTCP();
            }
            else if (udpFlag == 1)
            {
                SendDataUDP();
            }
            else
            {
                textBox1.Text += "Please choose a mode! \r\n";
            }

        }
        private void UDPbutton_CheckedChanged(object sender, EventArgs e)
        {
            if (UDPbutton.Checked) 
            {
                udpFlag = 1;
                tcpFlag = 0;
                textBox1.Text += "UDP Mode On! \r\n";
            }
        }

        private void TCPbutton_CheckedChanged(object sender, EventArgs e)
        {
            if (TCPbutton.Checked) 
            {
                udpFlag = 0;
                tcpFlag = 1;
                textBox1.Text += "TCP Mode On! \r\n";
            }
        }
    }

}