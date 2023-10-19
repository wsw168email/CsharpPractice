using CoordinateTransformLibrary;
using System.Runtime.CompilerServices;

namespace NEMA0183DecodeLibrary
{
    public class NEMA0183DecodeLibrary
    {
        public struct DataTranform
        {
            public double lat;
            public double lon;
            public float speed;
            public float sDirection;
            public float hDirection;
        }
        public static DataTranform DT = new DataTranform();
        public static int RMCflag = 0;
        public static int HDTflag = 0;
        public static int Decode(string result, StreamWriter sw)
        {
            string[] resultsubs = result.Split(',', '*');
            //去除字串矩陣中的空元素
            //resultsubs = resultsubs.Except(new List<string> { string.Empty }).ToArray();

            //提取GPS編碼型式
            string Starter = resultsubs[0];
            int finder = Starter.IndexOf("$");
            Starter = Starter.Substring(finder + 3);

            string londegree = "";
            string latdegree = "";
            int lonD = 0;
            int lonM = 0;
            double lonS = 0;
            int latD = 0;
            int latM = 0;
            double latS = 0;
            string time = "";
            string hour = "";
            string minute = "";
            string second = "";
            string data = "";


            if (Starter == "GGA")
            {
                for (int i = 0; i < resultsubs.Length; i++)
                {
                    switch (i)
                    {
                        case 0:
                            sw.WriteLine(Starter);
                            break;
                        case 1:
                            time = resultsubs[i];
                            hour += Char.ToString(time[0]) + Char.ToString(time[1]);
                            minute += Char.ToString(time[2]) + Char.ToString(time[3]);
                            second += Char.ToString(time[4]) + Char.ToString(time[5]) + Char.ToString(time[6]) + Char.ToString(time[7]) + Char.ToString(time[8]);

                            sw.WriteLine(hour + "時" + minute + "分" + second + "秒");
                            break;
                        case 2:
                            latdegree = resultsubs[i];
                            data = "";
                            data += Convert.ToString(latdegree[0]) + Convert.ToString(latdegree[1]);
                            latD = Convert.ToInt32(data);
                            data = "";
                            data += Convert.ToString(latdegree[2]) + Convert.ToString(latdegree[3]);
                            latM = Convert.ToInt32(data);
                            data = "";
                            finder = latdegree.IndexOf(".");
                            data += latdegree.Substring(finder + 1);
                            latS = Convert.ToDouble(data) / 100000000 * 60;
                            
                            break;
                        case 3:
                            if (resultsubs[i] == "N")
                            {
                               
                                sw.WriteLine("北緯(WGS84):" + Convert.ToString(latD) + "度" + Convert.ToString(latM) + "分" + latS.ToString("#.########") + "秒");
                            }
                            else
                            {
                                
                                sw.WriteLine("南緯(WGS84):" + Convert.ToString(latD) + "度" + Convert.ToString(latM) + "分" + latS.ToString("#.########") + "秒");
                            }
                            break;
                        case 4:
                            londegree = resultsubs[i];
                            data = "";
                            data += Convert.ToString(londegree[0]) + Convert.ToString(londegree[1]) + Convert.ToString(londegree[2]);
                            lonD = Convert.ToInt32(data);
                            data = "";
                            data += Convert.ToString(londegree[3]) + Convert.ToString(londegree[4]);
                            lonM = Convert.ToInt32(data);
                            data = "";
                            finder = londegree.IndexOf(".");
                            data += londegree.Substring(finder + 1);
                            lonS = Convert.ToDouble(data) / 100000000 * 60;
                            break;
                        case 5:
                            if (resultsubs[i] == "E")
                            {
                                
                                sw.WriteLine("東經(WGS84):" + Convert.ToString(lonD) + "度" + Convert.ToString(lonM) + "分" + lonS.ToString("#.#######") + "秒");
                            }
                            else
                            {
                                
                                sw.WriteLine("西經(WGS84):" + Convert.ToString(lonD) + "度" + Convert.ToString(lonM) + "分" + lonS.ToString("#.#######") + "秒");
                            }
                            data = "";
                            data = CoordinateTransform.lonlat_To_twd97(lonD, lonM, lonS, latD, latM, latS);
                            string[] dataSplit = data.Split(',');
                            if (resultsubs[3] == "N")
                            {
                                DT.lon = Convert.ToDouble(dataSplit[1]);
                                sw.WriteLine("北緯(TWD97):" + dataSplit[1]);
                            }
                            else
                            {
                                DT.lon = Convert.ToDouble(dataSplit[1]);
                                sw.WriteLine("南緯(TWD97):" + dataSplit[1]);
                            }
                            if (resultsubs[5] == "E")
                            {
                                DT.lat = Convert.ToDouble(dataSplit[0]);
                                sw.WriteLine("東經(TWD97):" + dataSplit[0]);
                            }
                            else
                            {
                                DT.lat = Convert.ToDouble(dataSplit[0]);
                                sw.WriteLine("西經(TWD97):" + dataSplit[0]);
                            }
                            break;
                        case 6:
                            if (resultsubs[i] == "0")
                            {
                                
                                sw.WriteLine("GPS狀態:未定位");
                            }
                            else if (resultsubs[i] == "1")
                            {
                                
                                sw.WriteLine("GPS狀態:非差分定位");
                            }
                            else if (resultsubs[i] == "2")
                            {
                                
                                sw.WriteLine("GPS狀態:差分定位");
                            }
                            else if (resultsubs[i] == "3")
                            {
                                
                                sw.WriteLine("GPS狀態:無效PPS");
                            }
                            else
                            {
                                
                                sw.WriteLine("GPS狀態:正在估算");
                            }
                            break;
                        case 7:
                            
                            sw.WriteLine("使用的衛星數量:" + resultsubs[i]);
                            break;
                        case 8:
                            
                            sw.WriteLine("HDOP水平精度因子:" + resultsubs[i]);
                            break;
                        case 9:
                            
                            sw.WriteLine("海拔高度:" + resultsubs[i] + resultsubs[i + 1]);
                            i++;
                            break;
                        case 11:
                            
                            sw.WriteLine("地球橢球面相對大地水準面的高度:" + resultsubs[i] + resultsubs[i + 1]);
                            i++;
                            break;
                        case 13:

                            sw.WriteLine("差分時間:" + resultsubs[i] + "秒");
                            break;
                        case 14:
     
                            sw.WriteLine("差分站ID:" + resultsubs[i]);
                            break;
                        case 15:
    
                            sw.WriteLine("校驗值:" + resultsubs[i]);
                            break;
                    }
                }
            }
            else if (Starter == "RMC")
            {
                RMCflag = 1;
                for (int i = 0; i < resultsubs.Length; i++)
                {
                    switch (i)
                    {
                        case 0:
  
                            sw.WriteLine(Starter);
                            break;
                        case 1:
                            time = resultsubs[i];
                            hour += Char.ToString(time[0]) + Char.ToString(time[1]);
                            minute += Char.ToString(time[2]) + Char.ToString(time[3]);
                            second += Char.ToString(time[4]) + Char.ToString(time[5]) + Char.ToString(time[6]) + Char.ToString(time[7]) + Char.ToString(time[8]);
 
                            sw.WriteLine(hour + "時" + minute + "分" + second + "秒");
                            break;
                        case 2:
                            if (resultsubs[i] == "V")
                            {
            
                                sw.WriteLine("GPS狀態:未定位");
                            }
                            else
                            {
                      
                                sw.WriteLine("GPS狀態:定位");
                            }
                            break;
                        case 3:
                            latdegree = resultsubs[i];
                            data = "";
                            data += Convert.ToString(latdegree[0]) + Convert.ToString(latdegree[1]);
                            latD = Convert.ToInt32(data);
                            data = "";
                            data += Convert.ToString(latdegree[2]) + Convert.ToString(latdegree[3]);
                            latM = Convert.ToInt32(data);
                            data = "";
                            finder = latdegree.IndexOf(".");
                            data += latdegree.Substring(finder + 1);
                            latS = Convert.ToDouble(data) / 100000000 * 60;
                            break;
                        case 4:
                            if (resultsubs[i] == "N")
                            {
                                
                                sw.WriteLine("北緯(WGS84):" + Convert.ToString(latD) + "度" + Convert.ToString(latM) + "分" + latS.ToString("#.#######") + "秒");
                            }
                            else
                            {
                                
                                sw.WriteLine("南緯(WGS84):" + Convert.ToString(latD) + "度" + Convert.ToString(latM) + "分" + latS.ToString("#.#######") + "秒");
                            }
                            break;
                        case 5:
                            londegree = resultsubs[i];
                            data = "";
                            data += Convert.ToString(londegree[0]) + Convert.ToString(londegree[1]) + Convert.ToString(londegree[2]);
                            lonD = Convert.ToInt32(data);
                            data = "";
                            data += Convert.ToString(londegree[3]) + Convert.ToString(londegree[4]);
                            lonM = Convert.ToInt32(data);
                            data = "";
                            finder = londegree.IndexOf(".");
                            data += londegree.Substring(finder + 1);
                            lonS = Convert.ToDouble(data) / 100000000 * 60;
                            break;
                        case 6:
                            if (resultsubs[i] == "E")
                            {
                                
                                sw.WriteLine("東經(WGS84):" + Convert.ToString(lonD) + "度" + Convert.ToString(lonM) + "分" + lonS.ToString("#.#######") + "秒");
                            }
                            else
                            {
                                
                                sw.WriteLine("西經(WGS84):" + Convert.ToString(lonD) + "度" + Convert.ToString(lonM) + "分" + lonS.ToString("#.#######") + "秒");
                            }
                            data = "";
                            data = CoordinateTransform.lonlat_To_twd97(lonD, lonM, lonS, latD, latM, latS);
                            string[] dataSplit = data.Split(',');
                            if (resultsubs[4] == "N")
                            {
                                DT.lon = Convert.ToDouble(dataSplit[1]);
                                sw.WriteLine("北緯(TWD97):" + dataSplit[1]);
                            }
                            else
                            {
                                DT.lon = Convert.ToDouble(dataSplit[1]);
                                sw.WriteLine("南緯(TWD97):" + dataSplit[1]);
                            }
                            if (resultsubs[6] == "E")
                            {
                                DT.lat = Convert.ToDouble(dataSplit[0]);
                                sw.WriteLine("東經(TWD97):" + dataSplit[0]);
                            }
                            else
                            {
                                DT.lat = Convert.ToDouble(dataSplit[0]);
                                sw.WriteLine("西經(TWD97):" + dataSplit[0]);
                            }
                            break;
                        case 7:
                            DT.speed = (float)Convert.ToDouble(resultsubs[i]);
                            sw.WriteLine("速度:" + resultsubs[i] + "節");
                            break;
                        case 8:
                            DT.sDirection = (float)Convert.ToDouble(resultsubs[i]);
                            sw.WriteLine("方位角:" + resultsubs[i]);
                            break;
                        case 9:
                            
                            sw.WriteLine("日期(UTC:)" + resultsubs[i]);
                            break;
                        case 10:
                            data = "";
                            data = resultsubs[i];
                            break;
                        case 11:
                            
                            sw.WriteLine("磁偏角:" + data + resultsubs[i]);
                            break;
                        case 12:
                            if (resultsubs[i] == "A")
                            {
                                
                                sw.WriteLine("模式指示:自主定位");
                            }
                            else if (resultsubs[i] == "D")
                            {
                                
                                sw.WriteLine("模式指示:差分");
                            }
                            else if (resultsubs[i] == "E")
                            {
                                
                                sw.WriteLine("模式指示:估算");
                            }
                            else
                            {
                                
                                sw.WriteLine("模式指示:資料無效");
                            }
                            break;
                        case 13:
                            
                            sw.WriteLine("校驗值:" + resultsubs[i]);
                            break;
                    }
                }
            }
            else if (Starter == "HDT")
            {
                HDTflag = 1;
                for (int i = 0; i < resultsubs.Length; i++)
                {
                    switch (i)
                    {
                        case 0:
                            
                            sw.WriteLine(Starter);
                            break;
                        case 1:
                            data = resultsubs[i];
                            break;
                        case 2:
                            if (resultsubs[i] == "T")
                            {
                                DT.hDirection = (float)Convert.ToDouble(data);
                                sw.WriteLine("船頭朝向(真北):" + data);
                            }
                            else
                            {
                                DT.hDirection = (float)Convert.ToDouble(data);
                                sw.WriteLine("船頭朝向:" + data);
                            }
                            break;
                        case 3:
                            
                            sw.WriteLine("校驗值:" + resultsubs[i]);
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Wrong Format!");
            }
            return 1;
        }
    }
}