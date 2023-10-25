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
        private readonly int _port;
        private UdpClient _udpClient;
        private IPEndPoint _serverEndpoint;
        

        public UdpClientSet(int port)
        {
            _port = port;
            _udpClient = new UdpClient(_port);
            _serverEndpoint = new IPEndPoint(IPAddress.Any, 0);
        }
        
        public async Task SendAndReceiveAsync()
        {
            // Receive data from the Server
            //UdpReceiveResult result = await _udpClient.ReceiveAsync();
            //_serverEndpoint = result.RemoteEndPoint;
            //string message = Encoding.ASCII.GetString(result.Buffer);
            //Form1.textBox1.Invoke(() => Form1.textBox1.Text += ($"Received on port {_port} from {result.RemoteEndPoint}: {message} \r\n"));
            
            while (true) 
            {
                // Receive data from the server
                UdpReceiveResult result = await _udpClient.ReceiveAsync();
                string response = Encoding.ASCII.GetString(result.Buffer);
                //if (response == "@")
                //{
                //    Form1.textBox1.Invoke(() => Form1.textBox1.Text = $"{_serverEndpoint.Port} Stream Complete! \r\n");
                //    if (_port == 8080) 
                //    {
                //        Form2.sw.Close();
                //    }
                    
                //    break;
                //}
                if (response[0] == '$')
                {
                    Form1.textBox1.Invoke(() => Form1.textBox1.Text += (response + $" form {_port} \r\n"));
                    int flag = 0;
                    while (flag != 1)
                    {
                        if (_port == 8080)
                        {
                            flag = NEMA0183DecodeLibrary.NEMA0183DecodeLibrary.Decode(response);
                        }
                        else
                        {
                            flag = OBSGL_DecodeLibrary.OBSGL_Decode.Decode(response);
                        }
                    }
                    
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
