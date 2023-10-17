using System;

namespace DecodeToExcelLibrary
{
    public class DecodeToExcel
    {
        

        public static void Decode() 
        {
            StreamReader sr = new StreamReader("E:\\Practice\\WinformTCPClient\\Decode.txt");
            StreamWriter sw = new StreamWriter("E:\\Practice\\WinformTCPClient\\DecodeToExcel.csv");
            String line;
            line = sr.ReadLine();
            sw.WriteLine("Hour,Minute,Second,Lon,Lat,Speed,SpeedDirection,HeadingDirection");
            //Continue to read until you reach end of file
            string[] time;
            string hour = "";
            string minute = "";
            string second = "";
            string lat = "";
            string lon = "";
            string speed = "";
            string speedDirection = "";
            string headingDirection = "";
            int found = 0;
            while (line != null)
            {
                if (line == "RMC")
                {
                    line = sr.ReadLine();
                    time = line.Split('時', '分', '秒');
                    hour = time[0];
                    minute = time[1];
                    second = time[2];
                    for (int i = 0; i < 4; i++)
                    {
                        line = sr.ReadLine();
                    }
                    found = line.IndexOf(":");
                    lat = line.Substring(found + 1);
                    line = sr.ReadLine();
                    found = line.IndexOf(":");
                    lon = line.Substring(found + 1);
                    line = sr.ReadLine();
                    found = line.IndexOf(":");
                    speed = line.Substring(found + 1, 5);
                    line = sr.ReadLine();
                    found = line.IndexOf(":");
                    speedDirection = line.Substring(found + 1);
                    //sw.WriteLine(hour + "," + minute + "," + second + "," + lon + "," + lat);
                }
                else if (line == "GGA")
                {
                    line = sr.ReadLine();
                    time = line.Split('時', '分', '秒');
                    hour = time[0];
                    minute = time[1];
                    second = time[2];
                    for (int i = 0; i < 3; i++)
                    {
                        line = sr.ReadLine();
                    }
                    found = line.IndexOf(":");
                    lat = line.Substring(found + 1);
                    line = sr.ReadLine();
                    found = line.IndexOf(":");
                    lon = line.Substring(found + 1);
                    //sw.WriteLine(hour + "," + minute + "," + second + "," + lon + "," + lat);
                }
                else if (line == "HDT")
                {
                    line = sr.ReadLine();
                    found = line.IndexOf(":");
                    headingDirection = line.Substring(found + 1);
                    sw.WriteLine(hour + "," + minute + "," + second + "," + lon + "," + lat + "," + speed + "," + speedDirection + "," + headingDirection);

                }
                else
                {
                    line = sr.ReadLine();
                }
            }
            //close the file
            sr.Close();
            sw.Close();
        }
        //Read the first line of text
        
    }
}