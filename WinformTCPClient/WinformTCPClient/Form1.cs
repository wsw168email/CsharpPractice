using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using NEMA0183DecodeLibrary;
using DecodeToExcelLibrary;

namespace WinformTCPClient
{
    public partial class Form1 : Form
    {
        int udpFlag = 0;
        int tcpFlag = 0;
        public Form1()
        {
            InitializeComponent();
            Form2 f = new Form2();
            f.Visible = true;

        }
        public static int MaindrawFlag;
        public static int SubdrawFlag;
        private async Task GetDataTCP()
        {
            TcpClient client1 = new TcpClient("127.0.0.1", new int[] { 8080, 8081 });
            await client1.StartAsync();
        }
        private async Task GetDataUDP()
        {
            List<int> ports = new List<int> { 8080, 8081 }; // List of ports to listen on
            Thread serverThread = new Thread(() =>
            {
                Parallel.ForEach(ports, port =>
                {
                    UdpClientSet server = new UdpClientSet(port);
                    server.SendAndReceiveAsync().Wait();
                });
            });
            serverThread.Start();

        }
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (tcpFlag == 1)
            {
                GetDataTCP();
            }
            else if (udpFlag == 1)
            {
                GetDataUDP();
            }
            else
            {
                textBox1.Text += ("Please choose a mode! \r\n");
            }

        }



        private void TCPbutton_CheckedChanged(object sender, EventArgs e)
        {
            if (TCPbutton.Checked)
            {
                udpFlag = 0;
                tcpFlag = 1;
                textBox1.Text += ("TCP mode On! \r\n");
            }
        }

        private void UDPbutton_CheckedChanged(object sender, EventArgs e)
        {
            if (UDPbutton.Checked)
            {
                udpFlag = 1;
                tcpFlag = 0;
                textBox1.Text += ("UDP mode On! \r\n");
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            Form2.sw.Close();
        }
    }
}