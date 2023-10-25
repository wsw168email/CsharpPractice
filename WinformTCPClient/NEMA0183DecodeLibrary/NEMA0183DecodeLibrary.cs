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
        public static DataTranform[] DT = new DataTranform[10];
        public static int RMCflag = 0;
        public static int HDTflag = 0;
        public static int RMCstartFlag = 0;
        static int RMCendFlag = 0;
        public static int HDTstartFlag = 0;
        static int HDTendFlag = 0;
        public static int Decode(string result)
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
                //for (int i = 0; i < resultsubs.Length; i++)
                //{
                //    switch (i)
                //    {
                        
                //        case 1:
                //            if (resultsubs[i] != "") 
                //            {
                //                time = resultsubs[i];
                //                hour += Char.ToString(time[0]) + Char.ToString(time[1]);
                //                minute += Char.ToString(time[2]) + Char.ToString(time[3]);
                //                second += Char.ToString(time[4]) + Char.ToString(time[5]) + Char.ToString(time[6]) + Char.ToString(time[7]) + Char.ToString(time[8]);
                                
                //            }
                            
                //            break;
                //        case 2:
                //            latdegree = resultsubs[i];
                //            data = "";
                //            data += Convert.ToString(latdegree[0]) + Convert.ToString(latdegree[1]);
                //            latD = Convert.ToInt32(data);
                //            data = "";
                //            data += Convert.ToString(latdegree[2]) + Convert.ToString(latdegree[3]);
                //            latM = Convert.ToInt32(data);
                //            data = "";
                //            finder = latdegree.IndexOf(".");
                //            data += latdegree.Substring(finder + 1);
                //            latS = Convert.ToDouble(data) / 100000000 * 60;
                            
                //            break;
                        
                //        case 4:
                //            londegree = resultsubs[i];
                //            data = "";
                //            data += Convert.ToString(londegree[0]) + Convert.ToString(londegree[1]) + Convert.ToString(londegree[2]);
                //            lonD = Convert.ToInt32(data);
                //            data = "";
                //            data += Convert.ToString(londegree[3]) + Convert.ToString(londegree[4]);
                //            lonM = Convert.ToInt32(data);
                //            data = "";
                //            finder = londegree.IndexOf(".");
                //            data += londegree.Substring(finder + 1);
                //            lonS = Convert.ToDouble(data) / 100000000 * 60;
                //            break;
                //        case 5:
                            
                //            data = "";
                //            data = CoordinateTransform.lonlat_To_twd97(lonD, lonM, lonS, latD, latM, latS);
                //            string[] dataSplit = data.Split(',');
                //            if (resultsubs[3] == "N")
                //            {
                //                DT.lon = Convert.ToDouble(dataSplit[1]);
                                
                //            }
                //            else
                //            {
                //                DT.lon = Convert.ToDouble(dataSplit[1]);
                                
                //            }
                //            if (resultsubs[5] == "E")
                //            {
                //                DT.lat = Convert.ToDouble(dataSplit[0]);
                                
                //            }
                //            else
                //            {
                //                DT.lat = Convert.ToDouble(dataSplit[0]);
                                
                //            }
                //            break;
                        
                        
                //    }
                //}
            }
            else if (Starter == "RMC")
            {
                RMCflag = 1;
                for (int i = 0; i < resultsubs.Length; i++)
                {
                    switch (i)
                    {
                        
                        case 1:
                            if (resultsubs[i] != "")
                            {
                                time = resultsubs[i];
                                hour += Char.ToString(time[0]) + Char.ToString(time[1]);
                                minute += Char.ToString(time[2]) + Char.ToString(time[3]);
                                second += Char.ToString(time[4]) + Char.ToString(time[5]) + Char.ToString(time[6]) + Char.ToString(time[7]) + Char.ToString(time[8]);
                                
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
                            
                            data = "";
                            data = CoordinateTransform.lonlat_To_twd97(lonD, lonM, lonS, latD, latM, latS);
                            string[] dataSplit = data.Split(',');
                            if (resultsubs[4] == "N")
                            {
                                DT[RMCendFlag].lon = Convert.ToDouble(dataSplit[1]);
                                
                            }
                            else
                            {
                                DT[RMCendFlag].lon = Convert.ToDouble(dataSplit[1]);
                                
                            }
                            if (resultsubs[6] == "E")
                            {
                                DT[RMCendFlag].lat = Convert.ToDouble(dataSplit[0]);
                                
                            }
                            else
                            {
                                DT[RMCendFlag].lat = Convert.ToDouble(dataSplit[0]);
                                
                            }
                            break;
                        case 7:
                            DT[RMCendFlag].speed = (float)Convert.ToDouble(resultsubs[i]);
                            
                            break;
                        case 8:
                            DT[RMCendFlag].sDirection = (float)Convert.ToDouble(resultsubs[i]);
                            
                            break;
                        
                    }
                }
                RMCendFlag++;
                
            }
            else if (Starter == "HDT")
            {
                HDTflag = 1;
                for (int i = 0; i < resultsubs.Length; i++)
                {
                    switch (i)
                    {
                        
                        case 1:
                            data = resultsubs[i];
                            break;
                        case 2:
                            if (resultsubs[i] == "T")
                            {
                                DT[HDTendFlag].hDirection = (float)Convert.ToDouble(data);
                            }
                            else
                            {
                                DT[HDTendFlag].hDirection = (float)Convert.ToDouble(data);
                            }
                            break;
                    }
                }
                HDTendFlag++;
            }
            else
            {
                Console.WriteLine("Wrong Format!");
            }

            //Circle Stack Start
            if (RMCendFlag == DT.Length) 
            {
                RMCendFlag = 0;
            }
            if (HDTendFlag == DT.Length) 
            {
                HDTendFlag = 0;
            }
            if (RMCendFlag == RMCstartFlag) 
            {
                RMCstartFlag++;
            }
            if (HDTendFlag == HDTstartFlag) 
            {
                HDTstartFlag++;
            }
            if (RMCstartFlag == DT.Length) 
            {
                RMCstartFlag = 0;
            }
            if (HDTstartFlag == DT.Length) 
            {
                HDTstartFlag = 0;
            }
            //Circle Stack End
            return 1;
        }
    }
}