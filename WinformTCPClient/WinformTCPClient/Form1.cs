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


        public Form1()
        {
            InitializeComponent();
        }
        private async Task ClientA()
        {
            StreamWriter sw = new StreamWriter("E:\\Practice\\WinformTCPClient\\Decode.txt");
            IPEndPoint ipEndPoint = new(IPAddress.Parse("127.0.0.1"), 8080);
            using TcpClient client = new();
            await client.ConnectAsync(ipEndPoint);
            await using NetworkStream stream = client.GetStream();
            ConnectShow.Invoke(() => ConnectShow.Text += ("Connection Success!\r\n"));
            while (true)
            {
                NetworkStream clientStream = client.GetStream();
                byte[] buffer = new byte[1024];
                int recv = await stream.ReadAsync(buffer);
                var message = Encoding.ASCII.GetString(buffer, 0, recv);
                string receive = "";
                for (int i = 0; i < recv; i++)
                {
                    receive += Convert.ToChar(message[i]);
                }
                if (receive == "@")
                {
                    sw.Close();
                    clientStream.Close();
                    textBox1.Invoke(() => textBox1.Text = "");
                    textBox1.Invoke(() => textBox1.Text += "Stream Complete!");
                    break;
                }
                if (receive[0] == '$')
                {
                    textBox1.Invoke(() => textBox1.Text += receive + "\r\n");
                    int flag = 0;
                    while (flag != 1)
                    {
                        flag = NEMA0183DecodeLibrary.NEMA0183DecodeLibrary.Decode(receive, sw);
                    }
                }

                await stream.WriteAsync(Encoding.ASCII.GetBytes("#")); //告訴發送端可以發送下一組數據


            }
        }
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            ClientA();
        }

        private void DecodeButton_Click(object sender, EventArgs e)
        {
            textBox1.Invoke(() => textBox1.Text = "");
            DecodeToExcelLibrary.DecodeToExcel.Decode();
            textBox1.Invoke(() => textBox1.Text += ("Decode Complete!\r\n"));
        }

        private void AnalysisButton_Click(object sender, EventArgs e)
        {

        }
    }
}