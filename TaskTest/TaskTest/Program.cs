using System;
using System.Threading;
using System.Threading.Tasks;

class Example
{
    static void Main()
    {

        Task myTask1 = new Task(() => {
            // Code for the task
            while (true) 
            {
                Console.WriteLine("Task1 is running");
                Thread.Sleep(1000);
            } 
        });
        Task myTask2 = new Task(() => {
            // Code for the task
            while (true)
            {
                Console.WriteLine("Task2 is running");
                Thread.Sleep(1000);
            }
        });
        Task myTask3 = new Task(() => {
            // Code for the task
            while (true)
            {
                Console.WriteLine("Task3 is running");
                Thread.Sleep(1000);
            }
        });
        myTask1.Start();
        myTask2.Start();
        myTask3.Start();
        Console.ReadLine();


    }
}

