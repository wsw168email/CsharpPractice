using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

class Client
{
    private string _serverIp;
    private int[] _serverPorts;

    public Client(string serverIp, int[] serverPorts)
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

    private async Task ConnectAndCommunicateAsync(int port)
    {
        TcpClient client = new TcpClient();
        try
        {
            await client.ConnectAsync(_serverIp, port);
            Console.WriteLine($"Connected to server on port {port}...");
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];

            while (true)
            {
                string message = null ;
                if (port == 1234)
                {
                    message = $"Hello, server on port {port} 1!";
                }
                else if (port == 1235)
                {
                    message = $"Hello, server on port {port} 2!";
                }
                else
                {

                }                
                byte[] messageBytes = Encoding.ASCII.GetBytes(message);
                await stream.WriteAsync(messageBytes, 0, messageBytes.Length);
                Console.WriteLine($"Sent message to server on port {port}...");
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                if (bytesRead == 0)
                {                    
                    Console.WriteLine($"Server on port {port} disconnected...");
                    break;                   
                }
                string response = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"Received from server on port {port}: {response}");
                await Task.Delay(1000);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error connecting to server on port {port}: {ex.Message}");
        }
        finally
        {
            client.Close();
        }
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        Client client = new Client("127.0.0.1", new int[] { 1234, 1235 });
        await client.StartAsync();
    }
}
