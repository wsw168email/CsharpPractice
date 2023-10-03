using System;
using System.Threading;
using uartPractice;

namespace uartPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Uart u = new Uart("COM4", 9600);
            u.OpenSerial();

            for (int i = 0; i < 10; i++)
            {
                string line = u.ReadLines();
                if (line != "")
                {
                    Console.Write(line);
                }
                Thread.Sleep(1000);
            }

            u.CloseSerial();
        }
    }
}