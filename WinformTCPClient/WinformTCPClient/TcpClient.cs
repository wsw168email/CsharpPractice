using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WinformTCPClient
{
    class TcpClient
    {
        private string _serverIp;
        private int[] _serverPorts;
        StreamWriter MainSW = new StreamWriter("E:\\Practice\\WinformTCPClient\\MainDecode.txt");
        StreamWriter SubSW = new StreamWriter("E:\\Practice\\WinformTCPClient\\SubDecode.txt");

        public TcpClient(string serverIp, int[] serverPorts)
        {
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
            System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient();
            try
            {
                await client.ConnectAsync(_serverIp, port);
                Form1.textBox1.Invoke(() => Form1.textBox1.Text += ($"Connected to server on port {port}... \r\n"));

                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];
                while (true)
                {
                    int bytesRead = await stream.ReadAsync(buffer);
                    if (bytesRead == 0)
                    {
                        Form1.textBox1.Invoke(() => Form1.textBox1.Text += ($"Server on port {port} disconnected... \r\n"));
                        break;
                    }
            
                    string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    
                    if (response == "@")
                    {
                        if (port == 8080)
                        {
                            MainSW.Close();
                        }
                        else 
                        {
                            SubSW.Close();
                        }

                        Form1.textBox1.Invoke(() => Form1.textBox1.Text = "");
                        Form1.textBox1.Invoke(() => Form1.textBox1.Text += $"{port} Stream Complete! \r\n");
                        break;
                    }
                    if (response[0] == '$')
                    {
                        Form1.textBox1.Invoke(() => Form1.textBox1.Text += (response + "\r\n"));
                        int flag = 0;
                        while (flag != 1)
                        {
                            if (port == 8080)
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
                    await stream.WriteAsync(Encoding.ASCII.GetBytes("#")); //告訴發送端可以發送下一組數據
                    await Task.Delay(10);
                }
            }
            catch (Exception ex)
            {
                Form1.textBox1.Invoke(() => Form1.textBox1.Text += ($"Error connecting to server on port {port}: {ex.Message}"));
            }
            finally
            {
                client.Close();
            }           
        }
    }
}
