using System.Net.Sockets;
using System.Text;

namespace WinformTCPClient
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        public BinaryReader br;
        public BinaryWriter bw;
        public Form1()
        {
            InitializeComponent();
        }
        private void ClientA()
        {

            client = new TcpClient("127.0.0.1", 8080);
            ConnectShow.Invoke(() => ConnectShow.Text += ("Connection Success!\r\n"));
            while (true)
            {                
                NetworkStream clientStream = client.GetStream();
                byte[] buffer = new byte[1024];
                int recv = clientStream.Read(buffer);
                var message = Encoding.ASCII.GetString(buffer, 0, recv);
                string receive = "";
                for (int i = 0; i < recv; i++)
                {
                    receive += Convert.ToChar(message[i]);
                }
                if (receive != "@")
                {
                    textBox1.Invoke(() => textBox1.Text += receive + "\r\n");
                    string s = "@";
                    byte[] dateTimeBytes = Encoding.ASCII.GetBytes(s);
                    clientStream.WriteAsync(dateTimeBytes, 0, dateTimeBytes.Length);
                }
                else 
                {
                    clientStream.Close();
                    break;
                }               
            }
        }
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            Thread myThread = new Thread(ClientA);
            myThread.Start();
        }


    }
}