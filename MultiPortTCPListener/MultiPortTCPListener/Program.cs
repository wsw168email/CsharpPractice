using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

class Server
{
    private TcpListener[] _servers;

    public Server(string ipAddress, int[] ports)
    {
        _servers = new TcpListener[ports.Length];
        for (int i = 0; i < ports.Length; i++)
        {
            _servers[i] = new TcpListener(IPAddress.Parse(ipAddress), ports[i]);
        }
    }

    public async Task StartAsync()
    {
        foreach (var server in _servers)
        {
            server.Start();
            Console.WriteLine($"Server started on port {((IPEndPoint)server.LocalEndpoint).Port}...");
        }

        var tasks = new List<Task>();
        foreach (var server in _servers)
        {
            tasks.Add(HandleServerAsync(server));
        }

        await Task.WhenAll(tasks);
    }

    private async Task HandleServerAsync(TcpListener server)
    {
        while (true)
        {
            TcpClient client = await server.AcceptTcpClientAsync();
            Console.WriteLine($"Client connected to port {((IPEndPoint)server.LocalEndpoint).Port}...");
            HandleClientAsync(client);
        }
    }

    private async Task HandleClientAsync(TcpClient client)
    {
        NetworkStream stream = client.GetStream();
        byte[] buffer = new byte[1024];

        while (true)
        {
            int bytesRead;
            try
            {
                bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
            }
            catch
            {
                Console.WriteLine("Client disconnected...");
                break;
            }

            if (bytesRead == 0)
            {
                Console.WriteLine("Client disconnected...");
                break;
            }

            string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            Console.WriteLine("Received: " + message);

            // Echo the message back to the client
            await stream.WriteAsync(buffer, 0, bytesRead);
        }

        client.Close();
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        Server server = new Server("127.0.0.1", new int[] { 1234, 1235 });
        await server.StartAsync();
    }
}