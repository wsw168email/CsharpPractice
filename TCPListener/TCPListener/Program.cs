using System.Net.Sockets;
using System.Net;
using System.Text;
using System;
using System.IO;

var ipEndPoint = new IPEndPoint(IPAddress.Any, 8080);
TcpListener listener = new(ipEndPoint);


try
{
    listener.Start();
    using TcpClient handler = await listener.AcceptTcpClientAsync();
    await using NetworkStream stream = handler.GetStream();

    //while (true) {
        string s = "";
        try
        {
            //填寫檔案位置
            StreamReader sr = new StreamReader("E:\\Practice\\TCPListener\\sample.txt");
            //讀取裡面的第一行
            s = sr.ReadLine();
            //讀取到沒有下一行為止
            while (s != null)
            {
                var buffer = new byte[1024];
                Console.WriteLine(s);
                var dateTimeBytes = Encoding.ASCII.GetBytes(s);
                await stream.WriteAsync(dateTimeBytes);
                await stream.ReadAsync(buffer);
                s = sr.ReadLine();
            }

        //關閉檔案
        var EndTimeBytes = Encoding.ASCII.GetBytes("@");
        await stream.WriteAsync(EndTimeBytes);//告訴接收端可以結束了
        sr.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
    //}
   
}
finally
{
    listener.Stop();
}

