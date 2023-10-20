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
            Form2 f = new Form2();
            f.Visible = true;

        }
        public static int MaindrawFlag;
        public static int SubdrawFlag;
        private async Task GetData()
        {
            Client client1 = new Client("127.0.0.1", new int[] { 8080,8081});
            await client1.StartAsync();
        }
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            GetData();
        }

    }
}