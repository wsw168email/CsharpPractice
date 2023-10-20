using System.Security.Cryptography.X509Certificates;

namespace OBSGL_DecodeLibrary
{
    public class OBSGL_Decode
    {
        public static int OBSGLflag = 0;
        public static List<ObjectionData> obj = new List<ObjectionData>();
        public static int Decode (string result)
        {
            int shipNumber = 0;
            string[] resultsubs = result.Split(',', '*');
            string[] filteredArray = resultsubs.Where(resultsubs => resultsubs != null).ToArray();
            shipNumber = Convert.ToInt32(filteredArray[1]);
            obj.Clear();
            for (int i = 0; i < shipNumber; i++)
            {
                obj.Add(new ObjectionData(Convert.ToInt32(filteredArray[2 + 9 * i]), Convert.ToInt32(filteredArray[3 + 9 * i]), (float)Convert.ToDouble(filteredArray[4 + 9 * i]), (float)Convert.ToDouble(filteredArray[5 + 9 * i]), (float)Convert.ToDouble(filteredArray[6 + 9 * i]), (float)Convert.ToDouble(filteredArray[7 + 9 * i]), (float)Convert.ToDouble(filteredArray[8 + 9 * i]), (float)Convert.ToDouble(filteredArray[9 + 9 * i]), (float)Convert.ToDouble(filteredArray[10 + 9 * i])));
            }
            OBSGLflag = 1;
            return 1;
        }
        public struct ObjectionData
        {
            public int ID;
            public int shipType;
            public float xX;
            public float yY;
            public float sX;
            public float sY;
            public float shipSize;
            public float hX;
            public float hY;
            public ObjectionData(int id, int shiptype, float xx, float yy, float sx, float sy, float shipsize, float hx, float hy)
            {
                ID = id;
                shipType = shiptype;
                xX = xx;
                yY = yy;
                sX = sx;
                sY = sy;
                shipSize = shipsize;
                hX = hx;
                hY = hy;
            }
        }
    }
}
