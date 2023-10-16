using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;

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

        private void StartButton_Click(object sender, EventArgs e)
        {
            //�Q��TcpClient.GetStream��k�o������y
            NetworkStream clientStream = newClient.GetStream();
            bw = new BinaryWriter(clientStream);
            string s = "";
            //��g�ɮצ�m
            StreamReader sr = new StreamReader("E:\\Practice\\TCPListener\\sample.txt");
            //Ū���̭����Ĥ@��
            s = sr.ReadLine();
            //Ū����S���U�@�欰��
            while (s != null)
            {
                byte[] dateTimeBytes = Encoding.ASCII.GetBytes(s);
                clientStream.Write(dateTimeBytes, 0, dateTimeBytes.Length);
                byte[] buffer = new byte[1024];
                clientStream.Read(buffer);                
                s = sr.ReadLine();
            }
            sr.Close();
            string endflag = "@";
            byte[] EndBytes = Encoding.ASCII.GetBytes(endflag);
            clientStream.Write(EndBytes, 0, EndBytes.Length);
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            myListener.Stop();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            myListener = new TcpListener(ip, 8080);
            myListener.Start();//start
            newClient = myListener.AcceptTcpClient();
            ConnectionShow.Invoke(() => ConnectionShow.Text += ("Connection Success!\r\n"));
        }
    }
}