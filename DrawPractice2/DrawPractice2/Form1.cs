using System.Drawing;
using System;
using System.Threading;



namespace DrawPractice2
{
    public partial class Form1 : Form
    {
        int timercount = 0;
        Image _image = null;//用於存放繪圖內容的中間載體image
        Graphics _Graphics = null;//在image上繪圖的畫布，不可見        
        Pen mypen = null;//畫筆       
        Graphics graphics = null;//窗體上繪圖的畫布，可見
        float formHeight;
        float formWidth;
        float[] xx = new float[102];
        float[] yy = new float[102];
        float xx1, yy1, xx2, yy2, xx3, yy3, xcenter, ycenter;
        float[][] result = MatrixCreate(1, 2);
        double length = 200;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            _image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            _Graphics = Graphics.FromImage(_image);//_Graphics是_image的畫布，將畫圖信息存在_image內
            mypen = new Pen(Color.Red);
            graphics = pictureBox1.CreateGraphics();//graphics為視窗畫布，用來顯示繪圖信息
            formHeight = pictureBox1.Height;
            formWidth = pictureBox1.Width;
            xcenter = (float)0.5 * formWidth;
            ycenter = (float)0.5 * formHeight;
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
        private void ReceiveButton_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timercount + 2 < 102)
            {
                _Graphics.Clear(Color.White);
                xx1 = xx[timercount];
                yy1 = yy[timercount];
                xx2 = xx[timercount + 1];
                yy2 = yy[timercount + 1];
                xx3 = xx[timercount + 2];
                yy3 = yy[timercount + 2];
                _Graphics.DrawLine(mypen, xx1, yy1, xx2, yy2);
                _Graphics.DrawLine(mypen, xx2, yy2, xx3, yy3);
                _Graphics.DrawLine(mypen, xcenter, ycenter, xx1, yy1);
                graphics.Clear(Color.White);
                graphics.DrawImage(_image, new Point(0, 0));
                timercount++;
            }
            else
            {
                timercount = 1;
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