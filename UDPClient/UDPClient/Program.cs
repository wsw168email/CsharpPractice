using System.IO;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace UDPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] data = new byte[1024];
            string input, stringData;

            //構建伺服器
            Console.WriteLine("This is a Client, host name is {0}", Dns.GetHostName());

            //設定服務IP，設定埠號
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);

            //定義網路型別，資料連線型別和網路協定UDP
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            string welcome = "Connected ";
            data = Encoding.UTF8.GetBytes(welcome);
            server.SendTo(data, data.Length, SocketFlags.None, ip);
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            EndPoint Remote = (EndPoint)sender;

            data = new byte[1024];
            //對於不存在的IP地址，加入此行程式碼後，可以在指定時間內解除阻塞模式限制
            int recv = server.ReceiveFrom(data, ref Remote);
            Console.WriteLine("Message received from {0}: ", Remote.ToString());
            Console.WriteLine(Encoding.UTF8.GetString(data, 0, recv));
            
            //將字串以ASCII編碼之後傳送
            string s = "" ;
            try
            {
                //填寫檔案位置
                StreamReader sr = new StreamReader("E:\\Practice\\UDPClient\\sample.txt");
                //讀取裡面的第一行
                s = sr.ReadLine();
                //讀取到沒有下一行為止
                while (s != null)
                {                  
                    Console.WriteLine(s);
                    server.SendTo(Encoding.ASCII.GetBytes(s), Remote);
                    s = sr.ReadLine();                    
                }
                //關閉檔案
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }            
            Console.WriteLine("Stopping Client.");
            server.Close();
        }

    }
}