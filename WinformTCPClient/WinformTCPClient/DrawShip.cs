using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NEMA0183DecodeLibrary;

namespace WinformTCPClient
{
    public class DrawShip
    {
        public static float[][] CT(float x, float y, float xminnow, float xmaxnow, float yminnow, float ymaxnow, float formWidth, float formHeight) //原點為畫布左下角
        {
            float[][] origin = MatrixCreate(1, 2);
            origin[0][0] = ((x - xminnow) / (xmaxnow - xminnow)) * formWidth;
            origin[0][1] = ((y - yminnow) / (ymaxnow - yminnow)) * formHeight;
            float[][] transform1 = MatrixCreate(2, 2);
            transform1[0][0] = 1;
            transform1[1][0] = 0;
            transform1[0][1] = 0;
            transform1[1][1] = -1;
            float[][] result = MatrixCreate(1, 2);
            result = MatrixProduct(origin, transform1);
            result[0][0] = result[0][0];
            result[0][1] = result[0][1] + formHeight;
            return result;
        }
        public static float[][] MatrixCreate(int rows, int cols)
        {
            // creates a matrix initialized to all 0.0s
            // do error checking here?
            float[][] result = new float[rows][];
            for (int i = 0; i < rows; ++i)
                result[i] = new float[cols]; // auto init to 0.0
            return result;
        }
        public static float[][] MatrixProduct(float[][] matrixA, float[][] matrixB)
        {
            int aRows = matrixA.Length; int aCols = matrixA[0].Length;
            int bRows = matrixB.Length; int bCols = matrixB[0].Length;
            if (aCols != bRows)
                throw new Exception("Non-conformable matrices in MatrixProduct");
            float[][] result = MatrixCreate(aRows, bCols);
            for (int i = 0; i < aRows; ++i) // each row of A
                for (int j = 0; j < bCols; ++j) // each col of B
                    for (int k = 0; k < aCols; ++k)
                        result[i][j] += matrixA[i][k] * matrixB[k][j];
            return result;
        }
        public static float[][] sDirection(float x, float y, float speedDirection)
        {
            float[][] resultoutput = MatrixCreate(1, 2);
            resultoutput[0][0] = x + (float)(0.005 * Math.Cos((speedDirection / 360.0) * 2 * Math.PI));
            resultoutput[0][1] = y + (float)(0.005 * Math.Sin((speedDirection / 360.0) * 2 * Math.PI));
            return resultoutput;
        }
        public static float[][] hDirection(float x, float y, float headingDirection)
        {
            float[][] resultoutput = MatrixCreate(1, 2);
            resultoutput[0][0] = x + (float)(0.005 * Math.Cos(((headingDirection / 360.0) * 2 * Math.PI)));
            resultoutput[0][1] = y + (float)(0.005 * Math.Sin(((headingDirection / 360.0) * 2 * Math.PI)));
            return resultoutput;
        }
        public static void LabelChange(double xbase, double ybase,float xminnow, float xmaxnow, float yminnow, float ymaxnow, float speedDirection, float headingDirection, float speed)
        {
            double xychange;
            xychange = xbase + (xmaxnow - xminnow) * (0.0) + xminnow;
            Form2.labelX0.Text = xychange.ToString("0.000");
            xychange = xbase + (xmaxnow - xminnow) * (0.1) + xminnow;
            Form2.labelX1.Text = xychange.ToString("0.000");
            xychange = xbase + (xmaxnow - xminnow) * (0.2) + xminnow;
            Form2.labelX2.Text = xychange.ToString("0.000");
            xychange = xbase + (xmaxnow - xminnow) * (0.3) + xminnow;
            Form2.labelX3.Text = xychange.ToString("0.000");
            xychange = xbase + (xmaxnow - xminnow) * (0.4) + xminnow;
            Form2.labelX4.Text = xychange.ToString("0.000");
            xychange = xbase + (xmaxnow - xminnow) * (0.5) + xminnow;
            Form2.labelX5.Text = xychange.ToString("0.000");
            xychange = xbase + (xmaxnow - xminnow) * (0.6) + xminnow;
            Form2.labelX6.Text = xychange.ToString("0.000");
            xychange = xbase + (xmaxnow - xminnow) * (0.7) + xminnow;
            Form2.labelX7.Text = xychange.ToString("0.000");
            xychange = xbase + (xmaxnow - xminnow) * (0.8) + xminnow;
            Form2.labelX8.Text = xychange.ToString("0.000");
            xychange = xbase + (xmaxnow - xminnow) * (0.9) + xminnow;
            Form2.labelX9.Text = xychange.ToString("0.000");
            xychange = ybase + (ymaxnow - yminnow) * 0.0 + yminnow;
            Form2.labelY0.Text = xychange.ToString("0.000");
            xychange = ybase + (ymaxnow - yminnow) * 0.1 + yminnow;
            Form2.labelY1.Text = xychange.ToString("0.000");
            xychange = ybase + (ymaxnow - yminnow) * 0.2 + yminnow;
            Form2.labelY2.Text = xychange.ToString("0.000");
            xychange = ybase + (ymaxnow - yminnow) * 0.3 + yminnow;
            Form2.labelY3.Text = xychange.ToString("0.000");
            xychange = ybase + (ymaxnow - yminnow) * 0.4 + yminnow;
            Form2.labelY4.Text = xychange.ToString("0.000");
            xychange = ybase + (ymaxnow - yminnow) * 0.5 + yminnow;
            Form2.labelY5.Text = xychange.ToString("0.000");
            xychange = ybase + (ymaxnow - yminnow) * 0.6 + yminnow;
            Form2.labelY6.Text = xychange.ToString("0.000");
            xychange = ybase + (ymaxnow - yminnow) * 0.7 + yminnow;
            Form2.labelY7.Text = xychange.ToString("0.000");
            xychange = ybase + (ymaxnow - yminnow) * 0.8 + yminnow;
            Form2.labelY8.Text = xychange.ToString("0.000");
            xychange = ybase + (ymaxnow - yminnow) * 0.9 + yminnow;
            Form2.labelY9.Text = xychange.ToString("0.000");
            xychange = speedDirection * (-1) + 90;
            if (xychange<0) 
            {
                xychange += 360;
            }
            Form2.SDirectionShow.Text = ("速度方向" + xychange.ToString("0.00") + "度");
            xychange = headingDirection * (-1) + 90;
            if (xychange < 0)
            {
                xychange += 360;
            }
            Form2.HDirectionShow.Text = ("船首方向" + xychange.ToString("0.00") + "度");
            Form2.SpeedShow.Text = ("速度" + speed + "節");
        }
    }
}
