using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

class UdpClientExample
{
    private UdpClient _udpClient;
    private IPEndPoint _serverEndpoint;

    public UdpClientExample(string serverIp, int port)
    {
        _udpClient = new UdpClient();
        _serverEndpoint = new IPEndPoint(IPAddress.Parse(serverIp), port);
    }

    public async Task SendAndReceiveAsync(string message)
    {
        
        // Send data to the server
        byte[] messageBytes = Encoding.ASCII.GetBytes(message);
        await _udpClient.SendAsync(messageBytes, messageBytes.Length, _serverEndpoint);
        Console.WriteLine($"Sent to {_serverEndpoint}: {message}");
        while (true)
        {
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
        string serverIp = "127.0.0.1";
        List<int> ports = new List<int> { 8080,8081 }; // List of ports to communicate with
        List<Task> clientTasks = new List<Task>();

        foreach (int port in ports)
        {
            UdpClientExample client = new UdpClientExample(serverIp, port);
            clientTasks.Add(client.SendAndReceiveAsync($"Hello from port {port}!"));
        }

        await Task.WhenAll(clientTasks);
    }
}

