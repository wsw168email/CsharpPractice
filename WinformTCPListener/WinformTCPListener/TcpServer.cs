using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WinformTCPListener
{
    class TcpServer
    {
        private TcpListener[] _servers;
        StreamReader FileRead;

        public TcpServer(string ipAddress, int[] ports)
        {
            _servers = new TcpListener[ports.Length];
            for (int i = 0; i < ports.Length; i++)
            {
                _servers[i] = new TcpListener(IPAddress.Parse(ipAddress), ports[i]);
            }

        }
        public async Task StartAsync()
        {
            foreach (var server in _servers)
            {
                server.Start();
                Form1.textBox1.Text += ($"Server started on port {((IPEndPoint)server.LocalEndpoint).Port}... \r\n");
            }
            var tasks = new List<Task>();
            foreach (var server in _servers)
            {
                tasks.Add(HandleServerAsync(server));
            }

            await Task.WhenAll(tasks);

        }

        private async Task HandleServerAsync(TcpListener server)
        {
            while (true)
            {
                TcpClient client = await server.AcceptTcpClientAsync();
                Form1.textBox1.Text += ($"Client connected to port {((IPEndPoint)server.LocalEndpoint).Port}... \r\n");
                if (((IPEndPoint)server.LocalEndpoint).Port == 8080)
                {
                    //填寫檔案位置
                    FileRead = new StreamReader("E:\\Practice\\WinformTCPListener\\sample.txt");
                }
                else 
                {
                    //填寫檔案位置
                    FileRead = new StreamReader("E:\\Practice\\WinformTCPListener\\sample2.txt");
                }
                HandleClientAsync(client, FileRead);
            }
        }
        
        private async Task HandleClientAsync(TcpClient client, StreamReader sr)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            string s = "";      
            //讀取裡面的第一行
            s = sr.ReadLine();
            //讀取到沒有下一行為止
            while (s != null)
            {
                var dateTimeBytes = Encoding.ASCII.GetBytes(s);
                await stream.WriteAsync(dateTimeBytes);
                await stream.ReadAsync(buffer);
                Thread.Sleep(10);
                s = sr.ReadLine();
            }
            var EndTimeBytes = Encoding.ASCII.GetBytes("@");
            await stream.WriteAsync(EndTimeBytes);//告訴接收端可以結束了
            Form1.textBox1.Invoke(() => Form1.textBox1.Text += ("Stream Complete!\r\n"));
            sr.Close();
            stream.Close();
            client.Close();
        }
    }
}
