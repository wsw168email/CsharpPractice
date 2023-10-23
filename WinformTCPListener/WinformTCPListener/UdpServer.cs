using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WinformTCPListener
{
    class UdpServer
    {
        private readonly int _port;
        private UdpClient _udpClient;
        private IPEndPoint _clientEndpoint;
        StreamReader FileRead ;

        public UdpServer(int port)
        {
            _port = port;
            _udpClient = new UdpClient(_port);
            _clientEndpoint = new IPEndPoint(IPAddress.Any, 0);
        }

        public async Task StartAsync()
        {            
            try
            {
                // Receive data from the client
                UdpReceiveResult result = await _udpClient.ReceiveAsync();
                _clientEndpoint = result.RemoteEndPoint;
                string message = Encoding.ASCII.GetString(result.Buffer);
                Form1.textBox1.Invoke(() => Form1.textBox1.Text += ($"Received on port {_port} from {result.RemoteEndPoint}: {message} \r\n"));
                if (_port == 8080)
                {
                    FileRead = new StreamReader("E:\\Practice\\WinformTCPListener\\Mainsample.txt");
                }
                else
                {
                    FileRead = new StreamReader("E:\\Practice\\WinformTCPListener\\Subsample.txt");
                }
                // Send a response to the client
                byte[] buffer = new byte[1024];
                string s = "";
                s = FileRead.ReadLine();
                while (s != null)
                {
                    var dateTimeBytes = Encoding.ASCII.GetBytes(s);
                    await _udpClient.SendAsync(dateTimeBytes, dateTimeBytes.Length, _clientEndpoint);
                    Thread.Sleep(10);
                    Form1.textBox1.Invoke(() => Form1.textBox1.Text += (s + $" From {_port}\r\n"));
                    s = FileRead.ReadLine();
                    if (_port == 8080)
                    {
                        Thread.Sleep(100);
                    }
                    else
                    {
                        Thread.Sleep(500);
                    }
                }
                Form1.textBox1.Text += ($" {_port} Stream Complete! \r\n");                              
            }
            catch (Exception ex)
            {
                Form1.textBox1.Text += ($"Error on port {_port}: {ex.Message} \r\n");
                await Task.Delay(1000); // Wait for a second before trying again
            }
        }
    }
}
