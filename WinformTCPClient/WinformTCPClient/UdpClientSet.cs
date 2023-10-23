using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WinformTCPClient
{
    internal class UdpClientSet
    {
        private UdpClient _udpClient;
        private IPEndPoint _serverEndpoint;
        StreamWriter MainSW = new StreamWriter("E:\\Practice\\WinformTCPClient\\MainDecode.txt");
        StreamWriter SubSW = new StreamWriter("E:\\Practice\\WinformTCPClient\\SubDecode.txt");

        public UdpClientSet(string serverIp, int port)
        {
            _udpClient = new UdpClient();
            _serverEndpoint = new IPEndPoint(IPAddress.Parse(serverIp), port);
        }

        public async Task SendAndReceiveAsync(string message)
        {
            // Send data to the server
            byte[] messageBytes = Encoding.ASCII.GetBytes(message);
            await _udpClient.SendAsync(messageBytes, messageBytes.Length, _serverEndpoint);
            Form1.textBox1.Text += ($"Sent to {_serverEndpoint}: {message} \r\n");
            while (true) 
            {
                // Receive data from the server
                UdpReceiveResult result = await _udpClient.ReceiveAsync();
                string response = Encoding.ASCII.GetString(result.Buffer);
                Form1.textBox1.Text += ($"Received from {result.RemoteEndPoint}: {response} \r\n");
                if (response == "@")
                {
                    if (_serverEndpoint.Port == 8080)
                    {
                        MainSW.Close();
                    }
                    else
                    {
                        SubSW.Close();
                    }

                    Form1.textBox1.Invoke(() => Form1.textBox1.Text = "");
                    break;
                }
                if (response[0] == '$')
                {
                    int flag = 0;
                    while (flag != 1)
                    {
                        if (_serverEndpoint.Port == 8080)
                        {
                            flag = NEMA0183DecodeLibrary.NEMA0183DecodeLibrary.Decode(response, MainSW);
                        }
                        else
                        {
                            flag = OBSGL_DecodeLibrary.OBSGL_Decode.Decode(response);
                        }
                    }
                    Form1.textBox1.Invoke(() => Form1.textBox1.Text += (response + "\r\n"));
                }
                if (NEMA0183DecodeLibrary.NEMA0183DecodeLibrary.RMCflag == 1 && NEMA0183DecodeLibrary.NEMA0183DecodeLibrary.HDTflag == 1)
                {
                    Form1.MaindrawFlag = 1;
                    while (Form1.MaindrawFlag != 0)
                    {
                        NEMA0183DecodeLibrary.NEMA0183DecodeLibrary.RMCflag = 0;
                        NEMA0183DecodeLibrary.NEMA0183DecodeLibrary.HDTflag = 0;
                    }

                }
                if (OBSGL_DecodeLibrary.OBSGL_Decode.OBSGLflag == 1)
                {
                    Form1.SubdrawFlag = 1;
                    while (Form1.SubdrawFlag != 0)
                    {
                        OBSGL_DecodeLibrary.OBSGL_Decode.OBSGLflag = 0;
                    }

                }
            }
            
        }
    }
}
