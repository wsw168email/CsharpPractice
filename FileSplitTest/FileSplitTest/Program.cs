using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Specify the file path
        string filePath = "E:\\Practice\\WinformTCPListener\\sample.txt";
        StreamWriter sw1 = new StreamWriter("E:\\Practice\\WinformTCPListener\\Mainsample.txt");
        StreamWriter sw2 = new StreamWriter("E:\\Practice\\WinformTCPListener\\Subsample.txt");

        // Check if the file exists
        if (File.Exists(filePath))
        {
            // Read all lines from the file
            string[] lines = File.ReadAllLines(filePath);

            // Print each non-empty line to the console
            foreach (string line in lines)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    Console.WriteLine(line);
                    string[]result = line.Split(',');
                    if (result[0] == "$OBSGL")
                    {
                        sw2.WriteLine(line);
                    }
                    else 
                    {
                        sw1.WriteLine(line);
                    }
                }
            }
            sw1.Close();
            sw2.Close();
        }
        else
        {
            Console.WriteLine("The file does not exist.");
        }
    }
}
