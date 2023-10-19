using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WinformTCPClient
{
    class Client
    {
        private TcpClient _client;
        private string _serverIp;
        private int[] _serverPorts;

        public Client(string serverIp, int[] serverPorts)
        {
            _client = new TcpClient();
            _serverIp = serverIp;
            _serverPorts = serverPorts;
        }
        public async Task StartAsync()
        {
            var tasks = new List<Task>();
            foreach (var port in _serverPorts)
            {
                tasks.Add(ConnectAndCommunicateAsync(port));
            }

            await Task.WhenAll(tasks);
        }

        public async Task ConnectAndCommunicateAsync(int port)
        {
            while (true)
            {
                try
                {
                    await _client.ConnectAsync(_serverIp, port);
                    Form1.textBox1.Invoke(() => Form1.textBox1.Text += $"Connected to server on port {port}...");
                    break;
                }
                catch
                {
                    Form1.textBox1.Invoke(() => Form1.textBox1.Text += "Failed to connect to server. Retrying... \r\n");
                    await Task.Delay(1000);
                }
            }

            NetworkStream stream = _client.GetStream();
            byte[] buffer = new byte[1024];
            StreamWriter sw = new StreamWriter("E:\\Practice\\WinformTCPClient\\Decode.txt");
            while (true)
            {
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                if (bytesRead == 0)
                {
                    Form1.textBox1.Invoke(() => Form1.textBox1.Text += "Server disconnected... \r\n");
                    break;
                }

                string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                
                if (response == "@")
                {
                    sw.Close();
                    
                    Form1.textBox1.Invoke(() => Form1.textBox1.Text = "");
                    Form1.textBox1.Invoke(() => Form1.textBox1.Text += "Stream Complete!");
                    break;
                }
                if (response[0] == '$')
                {
                    //Form1.textBox1.Invoke(() => Form1.textBox1.Text += (response + "\r\n"));
                    int flag = 0;
                    while (flag != 1)
                    {
                        flag = NEMA0183DecodeLibrary.NEMA0183DecodeLibrary.Decode(response, sw);
                    }
                }
                if (NEMA0183DecodeLibrary.NEMA0183DecodeLibrary.RMCflag == 1 && NEMA0183DecodeLibrary.NEMA0183DecodeLibrary.HDTflag == 1)
                {
                    Form1.drawFlag = 1;
                    while (Form1.drawFlag != 0)
                    {
                        NEMA0183DecodeLibrary.NEMA0183DecodeLibrary.RMCflag = 0;
                        NEMA0183DecodeLibrary.NEMA0183DecodeLibrary.HDTflag = 0;
                    }

                }
                await stream.WriteAsync(Encoding.ASCII.GetBytes("#")); //告訴發送端可以發送下一組數據
                Thread.Sleep(10);
            }

            _client.Close();
        }
    }
}
