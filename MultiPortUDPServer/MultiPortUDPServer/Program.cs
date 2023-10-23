using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

class UdpServer
{
    private readonly int _port;
    private UdpClient _udpClient;
    private IPEndPoint _clientEndpoint;

    public UdpServer(int port)
    {
        _port = port;
        _udpClient = new UdpClient(_port);
        _clientEndpoint = new IPEndPoint(IPAddress.Any, 0);
    }

    public async Task StartAsync()
    {
        Console.WriteLine($"Server is running on port {_port}...");

        while (true)
        {
            try
            {
                // Receive data from the client
                UdpReceiveResult result = await _udpClient.ReceiveAsync();
                _clientEndpoint = result.RemoteEndPoint;
                string message = Encoding.ASCII.GetString(result.Buffer);
                Console.WriteLine($"Received on port {_port} from {result.RemoteEndPoint}: {message}");
                // Send a response to the client
                byte[] responseBytes = Encoding.ASCII.GetBytes($"Hello from port {_port}!");
                await _udpClient.SendAsync(responseBytes, responseBytes.Length, _clientEndpoint);
                Console.WriteLine($"Sent to {_clientEndpoint}: Hello from port {_port}!");               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error on port {_port}: {ex.Message}");
                await Task.Delay(1000); // Wait for a second before trying again
            }
        }
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        List<int> ports = new List<int> { 12345, 12346, 12347 }; // List of ports to listen on
        List<Task> serverTasks = new List<Task>();

        foreach (int port in ports)
        {
            UdpServer server = new UdpServer(port);
            serverTasks.Add(server.StartAsync());
        }

        await Task.WhenAll(serverTasks);
    }
}

