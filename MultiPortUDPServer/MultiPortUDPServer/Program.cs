using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

class UdpServer
{
    private UdpClient _udpClient;
    private IPEndPoint _clientEndpoint;

    public UdpServer(string serverIp, int port)
    {
        _udpClient = new UdpClient();
        _clientEndpoint = new IPEndPoint(IPAddress.Parse(serverIp), port);
    }

    public async Task SendAndReceiveAsync(string message)
    {


        while (true)
        {
            // Send data to the server
            byte[] messageBytes = Encoding.ASCII.GetBytes(message);
            await _udpClient.SendAsync(messageBytes, messageBytes.Length, _clientEndpoint);
            Console.WriteLine($"Sent to {_clientEndpoint}: {message}");
            // Receive data from the server
            UdpReceiveResult result = await _udpClient.ReceiveAsync();
            string response = Encoding.ASCII.GetString(result.Buffer);
            Console.WriteLine(response);
        }


    }
    
}

class Program
{
    static async Task Main(string[] args)
    {
        string serverIp = "192.168.10.198";
        List<int> ports = new List<int> { 8080, 8081 }; // List of ports to communicate with
        List<Task> serverTasks = new List<Task>();

        foreach (int port in ports)
        {
            UdpServer client = new UdpServer(serverIp, port);
            serverTasks.Add(client.SendAndReceiveAsync($"Hello from port {port}!"));
        }

        await Task.WhenAll(serverTasks);
        
    }
}

