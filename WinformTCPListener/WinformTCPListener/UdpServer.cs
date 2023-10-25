using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace WinformTCPListener
{
    class UdpServer
    {
        private UdpClient _udpClient;
        private IPEndPoint _clientEndpoint;
        StreamReader FileRead;

        public UdpServer(string serverIp, int port)
        {
            _udpClient = new UdpClient();
            _clientEndpoint = new IPEndPoint(IPAddress.Parse(serverIp), port);
        }
        

        public async Task StartAsync(string message)
        {            
            try
            {
                // Send data to the client
                byte[] messageBytes = Encoding.ASCII.GetBytes(message);
                await _udpClient.SendAsync(messageBytes, messageBytes.Length, _clientEndpoint);
                Form1.textBox1.Invoke(() => Form1.textBox1.Text += ($"Sent to {_clientEndpoint}: {message} \r\n"));
                if (_clientEndpoint.Port ==  8080)
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
                    //Form1.textBox1.Invoke(() => Form1.textBox1.Text += (s + $" From {_port}\r\n"));
                    s = FileRead.ReadLine();
                    if (_clientEndpoint.Port == 8080)
                    {
                        Thread.Sleep(100);
                    }
                    else
                    {
                        Thread.Sleep(500);
                    }
                }
                Form1.textBox1.Invoke(()=>Form1.textBox1.Text += ($" {_clientEndpoint.Port} Stream Complete! \r\n"));
                var EndTimeBytes = Encoding.ASCII.GetBytes("@");
                await _udpClient.SendAsync(EndTimeBytes,EndTimeBytes.Length,_clientEndpoint);//告訴接收端可以結束了
            }
            catch (Exception ex)
            {
                Form1.textBox1.Invoke(()=>Form1.textBox1.Text += ($"Error on port {_clientEndpoint.Port}: {ex.Message} \r\n"));
                await Task.Delay(1000); // Wait for a second before trying again
            }
        }
    }
}
