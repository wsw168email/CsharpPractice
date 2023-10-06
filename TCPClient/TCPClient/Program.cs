using System.Net.Sockets;
using System.Net;
using System.Text;
using NEMA0183DecodeLibrary;
using System.IO;

StreamWriter sw = new StreamWriter("E:\\Practice\\TCPClient\\Decode.txt");
IPEndPoint ipEndPoint = new(IPAddress.Parse("127.0.0.1"),8080);

using TcpClient client = new();
await client.ConnectAsync(ipEndPoint);
await using NetworkStream stream = client.GetStream();

while (true) 
{
    var buffer = new byte[1024];

    int recv = await stream.ReadAsync(buffer);
    Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, recv));

    var message = Encoding.ASCII.GetString(buffer, 0, recv);
    string datarecv = "";
    for (int i = 0; i < recv; i++)
    {
        datarecv += Convert.ToChar(message[i]);
    }
    if (datarecv == "@") 
    {
        sw.Close();
        break;
    }
    if (datarecv[0] == '$')
    {
        int flag = 0;
        while (flag != 1)
        {
            flag = NEMA0183DecodeLibrary.NEMA0183DecodeLibrary.Decode(datarecv,sw);
        }
    }
    else 
    {
        Console.WriteLine("Noise!");
    }
    
    await stream.WriteAsync(Encoding.ASCII.GetBytes("#")); //告訴發送端可以發送下一組數據
}



