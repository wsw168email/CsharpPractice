//將String轉換成ASCII發送

string str2 = "$GPGGA,082204.999,4250.5589,S,14718.5084,E,1,04,24.4,19.7,M,0,M,34,0475,0000*1F";
Console.WriteLine(str2);
byte[] array = System.Text.Encoding.ASCII.GetBytes(str2);  //矩陣array為對應的ASCII矩陣     
string ASCIIstr2 = null;
for (int i = 0; i < array.Length; i++)
{
    if (i < array.Length - 1)
    {
        int asciicode = (int)(array[i]);
        ASCIIstr2 += Convert.ToString(asciicode) + ',';//字符串ASCIIstr2 為對應的ASCII字符串
    }
    else 
    {
        int asciicode = (int)(array[i]);
        ASCIIstr2 += Convert.ToString(asciicode) ;//字符串ASCIIstr2 為對應的ASCII字符串
    }
    
}

//Console.WriteLine(str2 +"\n"+ ASCIIstr2); //檢查

//將接收的ASCII轉換回String


int codeLength = ASCIIstr2.Length;
int str2int = 0;
string result = null;

string[] subs = ASCIIstr2.Split(',');
int arraylength = subs.Length;
for (int i = 0; i < arraylength; i++) 
{
    str2int = Convert.ToInt32(subs[i]); //ASCII字串轉INT
    result += System.Convert.ToChar(str2int);
}


//解析接收的數據

string[] resultsubs = result.Split(',');
string degree = "";
string time = "";
string hour = "";
string minute = "";
string second = "";

for(int i = 0; i<16;i++)
{
    switch (i) 
    { 
        case 0:
            Console.WriteLine("Global Positioning System Fix Data（GGA）GPS定位信息");
            break;
        case 1:
            time = resultsubs[i];
            hour += Char.ToString(time[0]) + Char.ToString(time[1]);
            minute += Char.ToString(time[2]) + Char.ToString(time[3]);
            second += Char.ToString(time[4]) + Char.ToString(time[5]) + Char.ToString(time[6]) + Char.ToString(time[7]) + Char.ToString(time[8]) + Char.ToString(time[9]);
            Console.WriteLine( hour + "時" + minute + "分" + second +"秒");
            break;
        case 2:
            degree = resultsubs[i];
            break;
        case 3:
            if (resultsubs[i] == "N")
            {
                Console.WriteLine("北緯:" + degree);
            }
            else 
            {
                Console.WriteLine("南緯:" + degree);
            }
            break;
        case 4:
            degree = resultsubs[i];
            break;
        case 5:
            if (resultsubs[i] == "E")
            {
                Console.WriteLine("東經:" + degree);
            }
            else
            {
                Console.WriteLine("西經:" + degree);
            }
            break;
        case 6:
            if (resultsubs[i] == "0")
            {
                Console.WriteLine("GPS狀態:未定位");
            }
            else if (resultsubs[i] == "1")
            {
                Console.WriteLine("GPS狀態:非差分定位");
            }
            else if (resultsubs[i] == "2")
            {
                Console.WriteLine("GPS狀態:差分定位");
            }
            else if (resultsubs[i] == "3")
            {
                Console.WriteLine("GPS狀態:無效PPS");
            }
            else 
            {
                Console.WriteLine("GPS狀態:正在估算");
            }
            break;
        case 7:
            Console.WriteLine("正在使用的衛星數量:" + resultsubs[i]);
            break;
        case 8:
            Console.WriteLine("HDOP水平精度因子:" + resultsubs[i]);
            break;
        case 9:
            degree = resultsubs[i];
            break;
        case 10:
            Console.WriteLine("海拔高度:" + degree + resultsubs[i]);
            break;
        case 11:
            degree = resultsubs[i];
            break;
        case 12:
            Console.WriteLine("地球橢球面相對大地水準面的高度:" + degree + resultsubs[i]);
            break;
        case 13:
            Console.WriteLine("差分時間:" + resultsubs[i]+"秒");
            break;
        case 14:
            Console.WriteLine("差分站ID號:" + resultsubs[i]);
            break;
        case 15:
            Console.WriteLine("校驗值:" + resultsubs[i]); 
            break;
    }
}





