using System.Text;
using System.Net;
using System.Net.Sockets;

namespace UDPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            int recv;
            byte[] data = new byte[1024];

            //得到本機IP，設定埠號         
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, 8080);
            Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            //繫結網路地址
            newsock.Bind(ip);

            Console.WriteLine("This is a Server, host name is {0}", Dns.GetHostName());

            //等待客戶機連線
            Console.WriteLine("Waiting for a client");

            //得到客戶機IP
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            EndPoint Remote = (EndPoint)(sender);
            recv = newsock.ReceiveFrom(data, ref Remote);
            Console.WriteLine("Message received from {0}: ", Remote.ToString());
            Console.WriteLine(Encoding.UTF8.GetString(data, 0, recv));

            //客戶機連線成功後，傳送資訊
            string welcome = "Connected ! ";

            //字串與位元組陣列相互轉換
            data = Encoding.UTF8.GetBytes(welcome);

            //傳送資訊
            newsock.SendTo(data, data.Length, SocketFlags.None, Remote);
            while (true)
            {
                data = new byte[1024];
                //接收資訊
                recv = newsock.ReceiveFrom(data, ref Remote);
                Console.WriteLine(Encoding.ASCII.GetString(data, 0, recv));
                string datarecv = "";
                for (int i = 0;i<recv;i++) 
                {
                    datarecv += Convert.ToChar(data[i]);                                
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
            }
        }

    }
}
