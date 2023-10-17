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
        private TcpListener myListener;
        private TcpClient newClient;
        public BinaryReader br;
        public BinaryWriter bw;

        public Form1()
        {
            InitializeComponent();
        }

        public async Task ServerA() 
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            myListener = new TcpListener(ip, 8080);
            myListener.Start();//start
            newClient = await myListener.AcceptTcpClientAsync();          
            ConnectionShow.Invoke(() => ConnectionShow.Text += ("Connection Success!\r\n"));
        }
        public async Task SendData() 
        {
            await using NetworkStream stream = newClient.GetStream();
            string s = "";
            //填寫檔案位置
            StreamReader sr = new StreamReader("E:\\Practice\\TCPListener\\sample.txt");
            //讀取裡面的第一行
            s = sr.ReadLine();
            //讀取到沒有下一行為止
            while (s != null)
            {
                var dateTimeBytes = Encoding.ASCII.GetBytes(s);
                await stream.WriteAsync(dateTimeBytes);
                var buffer = new byte[1024];
                await stream.ReadAsync(buffer);
                Thread.Sleep(10);
                s = sr.ReadLine();
            }
            var EndTimeBytes = Encoding.ASCII.GetBytes("@");
            await stream.WriteAsync(EndTimeBytes);//告訴接收端可以結束了
            sr.Close();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            SendData(); 
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            myListener.Stop();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            ServerA();
        }
    }
}