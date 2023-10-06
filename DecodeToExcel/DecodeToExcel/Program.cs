using System.IO;

String line;
try
{
    //Pass the file path and file name to the StreamReader constructor
    StreamReader sr = new StreamReader("E:\\Practice\\DecodeToExcel\\Decode.txt");
    StreamWriter sw = new StreamWriter("E:\\Practice\\DecodeToExcel\\DecodeToExcel.txt");
    //Read the first line of text
    line = sr.ReadLine();
    sw.WriteLine("Hour,Minute,Second,Lat,Lon");
    //Continue to read until you reach end of file
    string[] time ;
    string hour = "";
    string minute = "";
    string second = "";
    string lat = "";
    string lon = "";
    int found = 0;
    while (line != null)
    {
        if (line == "RMC")
        {
            line = sr.ReadLine();
            time = line.Split('時','分','秒');
            hour = time[0];
            minute = time[1];
            second = time[2];
            for (int i = 1; i < 5; i++) {
                line = sr.ReadLine();
            }
            found = line.IndexOf(":");
            lat = line.Substring(found + 1);
            line = sr.ReadLine();
            found = line.IndexOf(":");
            lon = line.Substring(found + 1);
            sw.WriteLine(hour + "," + minute + "," + second + "," + lon + "," + lat);
        }
        else if (line == "GGA")
        {
            line = sr.ReadLine();
        }
        else 
        {
            line = sr.ReadLine();
        }
        Console.WriteLine(line);
    }
    //close the file
    sr.Close();
    sw.Close();
    Console.ReadLine();
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
finally
{
    Console.WriteLine("Executing finally block.");
}