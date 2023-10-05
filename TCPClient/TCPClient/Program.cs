using System.Net.Sockets;
using System.Net;
using System.Text;

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
        break;
    }

    string degree = ""; //紀錄欄位數據
    string[] resultsubs = datarecv.Split(','); //切割
    for (int i = 0; i < 10; i++)
    {
        switch (i)
        {
            case 0:
                Console.WriteLine("" + resultsubs[i] + "Track Made Good and Ground Speed（VTG)");
                break;
            case 1:
                degree = resultsubs[i];
                break;
            case 2:
                Console.WriteLine("真北參照系運動角度:" + degree + "度");
                break;
            case 3:
                degree = resultsubs[i];
                break;
            case 4:
                Console.WriteLine("磁北參照系運動角度:" + degree + "度");
                break;
            case 5:
                degree = resultsubs[i];
                break;
            case 6:
                Console.WriteLine("水平運動速度:" + degree + "節");
                break;
            case 7:
                degree = resultsubs[i];
                break;
            case 8:
                Console.WriteLine("水平運動速度:" + degree + "km/h");
                break;
            case 9:
                Console.WriteLine("校驗值:" + resultsubs[i]);
                break;
        }
    }
    await stream.WriteAsync(Encoding.ASCII.GetBytes("#")); //告訴發送端可以發送下一組數據
}



