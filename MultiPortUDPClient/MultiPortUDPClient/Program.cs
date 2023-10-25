using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

class UdpClientExample
{
    private readonly int _port;
    private UdpClient _udpClient;
    private IPEndPoint _serverEndpoint;

    public UdpClientExample(int port)
    {
        _port = port;
        _udpClient = new UdpClient(_port);
        _serverEndpoint = new IPEndPoint(IPAddress.Any, 0);
    }

    public async Task StartAsync()
    {
        Console.WriteLine($"Client is running on port {_port}...");

        while (true)
        {
            try
            {
                // Receive data from the client
                UdpReceiveResult result = await _udpClient.ReceiveAsync();
                _serverEndpoint = result.RemoteEndPoint;
                string message = Encoding.ASCII.GetString(result.Buffer);
                Console.WriteLine($"Received on port {_port} from {result.RemoteEndPoint}: {message}");
                // Send a response to the client
                byte[] responseBytes = Encoding.ASCII.GetBytes($"Hello from port {_port}!");
                await _udpClient.SendAsync(responseBytes, responseBytes.Length, _serverEndpoint);
                Console.WriteLine($"Sent to {_serverEndpoint}: Hello from port {_port}!");
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
        List<int> ports = new List<int> { 8080, 8081 }; // List of ports to listen on
        List<Task> clientTasks = new List<Task>();

        foreach (int port in ports)
        {
            UdpClientExample client = new UdpClientExample(port);
            clientTasks.Add(client.StartAsync());
        }

        await Task.WhenAll(clientTasks);
    }
}

