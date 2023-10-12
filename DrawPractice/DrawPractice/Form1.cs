using System.Drawing;
using System;
using System.Threading;
using ScottPlot;

namespace DrawPractice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static float[][] CT(float x, float y, float formHeight)
        {
            float[][] origin = MatrixCreate(1, 2);
            origin[0][0] = x;
            origin[0][1] = y;
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

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            float formHeight = this.Height;
            float formWidth = this.Width;
            float[] xx = new float[102];
            float[] yy = new float[102];
            float xx1;
            float yy1;
            float xx2;
            float yy2;
            float xx3;
            float yy3;
            float xcenter = (float)0.5* formWidth;
            float ycenter = (float)0.25* formHeight;
            double length = 200;
            float[][] result = MatrixCreate(1, 2);

            Graphics g = this.CreateGraphics();
            g.Clear(Color.White);

            for (int i = 0; i < 102; i++)
            {
                xx[i] = (float)Convert.ToDouble(Math.Cos(Convert.ToDouble(i) / 100 * 2 * Math.PI) * length + xcenter);
                yy[i] = (float)Convert.ToDouble(Math.Sin(Convert.ToDouble(i) / 100 * 2 * Math.PI) * length + ycenter);
                result = CT(xx[i], yy[i], formHeight);
                xx[i] = result[0][0];
                yy[i] = result[0][1];
            }
            result = CT(xcenter, ycenter, formHeight);
            xcenter = result[0][0];
            ycenter = result[0][1];
            Pen p = new Pen(Color.Blue);
            g.DrawLine(p, xcenter, ycenter, (float)0.5 * formWidth, (float)0.5 * formHeight);
            g.DrawLine(p,0, 0, formWidth,  formHeight);
            g.DrawLine(p, 0, formHeight, formWidth, 0);
            //while (true)
            //{
            //    for (int i = 0; i < 100; i++)
            //    {
            //        if (i + 2 < 102)
            //        {
            //            g.Clear(Color.White);
            //            xx1 = xx[i];
            //            yy1 = yy[i];
            //            xx2 = xx[i + 1];
            //            yy2 = yy[i + 1];
            //            xx3 = xx[i + 2];
            //            yy3 = yy[i + 2];
            //            g.DrawLine(p, xx1, yy1, xx2, yy2);
            //            g.DrawLine(p, xx2, yy2, xx3, yy3);
            //            g.DrawLine(p, xcenter, ycenter, xx1, yy1);
            //            Thread.Sleep(50);
            //        }
            //        else
            //        {
            //            break;
            //        }
            //    }
            //}

        }
    }
}