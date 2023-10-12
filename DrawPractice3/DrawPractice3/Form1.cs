using System.Drawing;
using System;
using System.Threading;

namespace DrawPractice3
{
    public partial class Form1 : Form
    {
        int datacount = 0;
        int timercount = 0;
        Image _image = null;//用於存放繪圖內容的中間載體image
        Graphics _Graphics = null;//在image上繪圖的畫布，不可見        
        Pen mypen = null;//畫筆       
        Graphics graphics = null;//窗體上繪圖的畫布，可見
        float formHeight;
        float formWidth;
        float[] xx = new float[1000];
        float[] yy = new float[1000];
        float xx1, yy1, xx2, yy2, xx3, yy3;
        float[][] result = MatrixCreate(1, 2);
        double length = 200;
        StreamReader sr = new StreamReader("E:\\Practice\\DrawPractice3\\DecodeToExcel.csv");
        String line;
        string[] data;
        float xmin = (float)0.32;
        float xmax = (float)0.34;
        float ymin = (float)0.2; 
        float ymax = (float)0.4;
        double datachange;

        public Form1()
        {
            InitializeComponent();
            _image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            _Graphics = Graphics.FromImage(_image);//_Graphics是_image的畫布，將畫圖信息存在_image內
            mypen = new Pen(Color.Red);
            graphics = pictureBox1.CreateGraphics();//graphics為視窗畫布，用來顯示繪圖信息
            formHeight = pictureBox1.Height;
            formWidth = pictureBox1.Width;
            line = sr.ReadLine();
            line = sr.ReadLine();
            while (line != null)
            {
                data = line.Split(",");
                datachange = Convert.ToDouble(data[3]) - 177698 ;
                xx[datacount] = (float)Convert.ToDouble(datachange);
                datachange = Convert.ToDouble(data[4]) - 2500798;
                yy[datacount] = (float)Convert.ToDouble(datachange);
                result = CT(xx[datacount], yy[datacount]);
                xx[datacount] = result[0][0];
                yy[datacount] = result[0][1];
                line = sr.ReadLine();
                datacount++;
            }
            
        }


        public float[][] CT(float x, float y)
        {
            float[][] origin = MatrixCreate(1, 2);
            origin[0][0] = ((x-xmin)/(xmax-xmin))*formWidth;
            origin[0][1] = ((y-ymin)/(ymax-ymin))*formHeight;
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
        private void ReceiveButton_Click(object sender, EventArgs e)
        {
            _Graphics.Clear(Color.White);
            graphics.Clear(Color.White);
            timer1.Enabled = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timercount + 1 < datacount)
            {
                //_Graphics.Clear(Color.White);
                xx1 = xx[timercount];
                yy1 = yy[timercount];
                xx2 = xx[timercount + 1];
                yy2 = yy[timercount + 1];
                _Graphics.DrawLine(mypen, xx1, yy1, xx2, yy2);
                //graphics.Clear(Color.White);
                graphics.DrawImage(_image, new Point(0, 0));
                timercount++;
            }
            else
            {
                timercount = 0;
                _Graphics.Clear(Color.White);
                graphics.Clear(Color.White);
            }

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            graphics.Clear(Color.White);
            graphics.DrawImage(_image, new Point(0, 0));
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            _Graphics.Clear(Color.White);
            graphics.Clear(Color.White);
            timercount = 0;
        }
    }
}