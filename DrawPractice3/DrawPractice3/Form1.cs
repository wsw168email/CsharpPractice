using System.Drawing;
using System;
using System.Threading;
using System.Security.Cryptography.X509Certificates;

namespace DrawPractice3
{
    public partial class Form1 : Form
    {
        int datacount = 0;
        int timercount = 0;
        Image _image = null;//用於存放繪圖內容的中間載體image
        Graphics _Graphics = null;//在image上繪圖的畫布，不可見        
        Pen mypen = null;//畫筆
        Pen dotpen = null;//畫筆 
        Graphics graphics = null;//窗體上繪圖的畫布，可見
        Image _imageDirection = null;
        Graphics _GraphicsDirection = null;
        Graphics grachicsDirection = null;
        Pen Sdirectionpen = null;
        Pen Hdirectionpen = null;
        float formHeight;
        float formWidth;
        float[] xx = new float[1000];
        float[] yy = new float[1000];
        float[] speed = new float[1000];
        float[] speedDirection = new float[1000];
        float[] headingDirection = new float[1000];
        float[] sXX = new float[1000];
        float[] sYY = new float[1000];
        float[] hXX = new float[1000];
        float[] hYY = new float[1000];
        float xx1, yy1, xx2, yy2, sxx, syy, hxx, hyy;
        float[][] result = MatrixCreate(1, 2);
        float[][] resultDirection = MatrixCreate(1, 2);
        private int xPos;
        private int yPos;

        String line;
        string[] data;
        float xmin = (float)0.2;
        float xmax = (float)0.4;
        float ymin = (float)0.2;
        float ymax = (float)0.4;
        float xminnow, xmaxnow, yminnow, ymaxnow;
        double xbase = 177698;
        double ybase = 2500798;
        float xcenter, ycenter;
        double datachange;
        float ZoomRatio = 1.0f;
        int dataread = 0;

        public Form1()
        {
            InitializeComponent();
            _image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            _imageDirection = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            _Graphics = Graphics.FromImage(_image);//_Graphics是_image的畫布，將畫圖信息存在_image內
            _GraphicsDirection = Graphics.FromImage(_imageDirection);
            mypen = new Pen(Color.Red, 5);
            dotpen = new Pen(Color.Gray);
            dotpen.DashPattern = new float[] { 10.0F, 2.0F };
            Sdirectionpen = new Pen(Color.Blue, 3);
            Hdirectionpen = new Pen(Color.Green, 3);
            graphics = pictureBox1.CreateGraphics();//graphics為視窗畫布，用來顯示繪圖信息
            grachicsDirection = pictureBox1.CreateGraphics();
            formHeight = pictureBox1.Height;
            formWidth = pictureBox1.Width;
            xminnow = xmin;
            xmaxnow = xmax;
            yminnow = ymin;
            ymaxnow = ymax;
            ShipGenerate();
            xcenter = (xmax - xmin) * 0.5f + xmin;
            ycenter = (ymax - ymin) * 0.5f + ymin;
            _Graphics.Clear(Color.White);
            _GraphicsDirection.Clear(Color.FromArgb(0, 255, 255, 255));
        }

        public void ShipGenerate()
        {
            StreamReader sr = new StreamReader("E:\\Practice\\DrawPractice3\\DecodeToExcel.csv");
            line = sr.ReadLine();
            line = sr.ReadLine();
            while (line != null)
            {
                data = line.Split(",");
                datachange = Convert.ToDouble(data[3]) - xbase;
                xx[dataread] = (float)datachange;
                datachange = Convert.ToDouble(data[4]) - ybase;
                yy[dataread] = (float)datachange;
                speed[dataread] = (float)Convert.ToDouble(data[5]);
                speedDirection[dataread] = (float)Convert.ToDouble(data[6]);
                headingDirection[dataread] = (float)Convert.ToDouble(data[7]);

                result = sDirection(xx[dataread], yy[dataread]);
                resultDirection = CT(result[0][0], result[0][1]);
                sXX[dataread] = resultDirection[0][0];
                sYY[dataread] = resultDirection[0][1];
                result = hDirection(xx[dataread], yy[dataread]);
                resultDirection = CT(result[0][0], result[0][1]);
                hXX[dataread] = resultDirection[0][0];
                hYY[dataread] = resultDirection[0][1];
                result = CT(xx[dataread], yy[dataread]);
                xx[dataread] = result[0][0];
                yy[dataread] = result[0][1];
                line = sr.ReadLine();
                datacount = dataread;
                dataread++;
            }
            dataread = 0;
            sr.Close();
        }

        //CoordinateTransform
        public float[][] CT(float x, float y)
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
        private void DotDraw()
        {
            _Graphics.DrawLine(dotpen, 0.1f * formWidth, 0, 0.1f * formWidth, formHeight);
            _Graphics.DrawLine(dotpen, 0.2f * formWidth, 0, 0.2f * formWidth, formHeight);
            _Graphics.DrawLine(dotpen, 0.3f * formWidth, 0, 0.3f * formWidth, formHeight);
            _Graphics.DrawLine(dotpen, 0.4f * formWidth, 0, 0.4f * formWidth, formHeight);
            _Graphics.DrawLine(dotpen, 0.5f * formWidth, 0, 0.5f * formWidth, formHeight);
            _Graphics.DrawLine(dotpen, 0.6f * formWidth, 0, 0.6f * formWidth, formHeight);
            _Graphics.DrawLine(dotpen, 0.7f * formWidth, 0, 0.7f * formWidth, formHeight);
            _Graphics.DrawLine(dotpen, 0.8f * formWidth, 0, 0.8f * formWidth, formHeight);
            _Graphics.DrawLine(dotpen, 0.9f * formWidth, 0, 0.9f * formWidth, formHeight);
            _Graphics.DrawLine(dotpen, 0, 0.1f * formHeight, formWidth, 0.1f * formHeight);
            _Graphics.DrawLine(dotpen, 0, 0.2f * formHeight, formWidth, 0.2f * formHeight);
            _Graphics.DrawLine(dotpen, 0, 0.3f * formHeight, formWidth, 0.3f * formHeight);
            _Graphics.DrawLine(dotpen, 0, 0.4f * formHeight, formWidth, 0.4f * formHeight);
            _Graphics.DrawLine(dotpen, 0, 0.5f * formHeight, formWidth, 0.5f * formHeight);
            _Graphics.DrawLine(dotpen, 0, 0.6f * formHeight, formWidth, 0.6f * formHeight);
            _Graphics.DrawLine(dotpen, 0, 0.7f * formHeight, formWidth, 0.7f * formHeight);
            _Graphics.DrawLine(dotpen, 0, 0.8f * formHeight, formWidth, 0.8f * formHeight);
            _Graphics.DrawLine(dotpen, 0, 0.9f * formHeight, formWidth, 0.9f * formHeight);
        }
        private void LabelChange()
        {
            double xychange;
            xychange = xbase + (xmaxnow - xminnow) * (0.0) + xminnow;
            labelX0.Text = xychange.ToString("0.000");
            xychange = xbase + (xmaxnow - xminnow) * (0.1) + xminnow;
            labelX1.Text = xychange.ToString("0.000");
            xychange = xbase + (xmaxnow - xminnow) * (0.2) + xminnow;
            labelX2.Text = xychange.ToString("0.000");
            xychange = xbase + (xmaxnow - xminnow) * (0.3) + xminnow;
            labelX3.Text = xychange.ToString("0.000");
            xychange = xbase + (xmaxnow - xminnow) * (0.4) + xminnow;
            labelX4.Text = xychange.ToString("0.000");
            xychange = xbase + (xmaxnow - xminnow) * (0.5) + xminnow;
            labelX5.Text = xychange.ToString("0.000");
            xychange = xbase + (xmaxnow - xminnow) * (0.6) + xminnow;
            labelX6.Text = xychange.ToString("0.000");
            xychange = xbase + (xmaxnow - xminnow) * (0.7) + xminnow;
            labelX7.Text = xychange.ToString("0.000");
            xychange = xbase + (xmaxnow - xminnow) * (0.8) + xminnow;
            labelX8.Text = xychange.ToString("0.000");
            xychange = xbase + (xmaxnow - xminnow) * (0.9) + xminnow;
            labelX9.Text = xychange.ToString("0.000");
            xychange = ybase + (ymaxnow - yminnow) * 0.0 + yminnow;
            labelY0.Text = xychange.ToString("0.000");
            xychange = ybase + (ymaxnow - yminnow) * 0.1 + yminnow;
            labelY1.Text = xychange.ToString("0.000");
            xychange = ybase + (ymaxnow - yminnow) * 0.2 + yminnow;
            labelY2.Text = xychange.ToString("0.000");
            xychange = ybase + (ymaxnow - yminnow) * 0.3 + yminnow;
            labelY3.Text = xychange.ToString("0.000");
            xychange = ybase + (ymaxnow - yminnow) * 0.4 + yminnow;
            labelY4.Text = xychange.ToString("0.000");
            xychange = ybase + (ymaxnow - yminnow) * 0.5 + yminnow;
            labelY5.Text = xychange.ToString("0.000");
            xychange = ybase + (ymaxnow - yminnow) * 0.6 + yminnow;
            labelY6.Text = xychange.ToString("0.000");
            xychange = ybase + (ymaxnow - yminnow) * 0.7 + yminnow;
            labelY7.Text = xychange.ToString("0.000");
            xychange = ybase + (ymaxnow - yminnow) * 0.8 + yminnow;
            labelY8.Text = xychange.ToString("0.000");
            xychange = ybase + (ymaxnow - yminnow) * 0.9 + yminnow;
            labelY9.Text = xychange.ToString("0.000");
            SDirectionShow.Text = ("速度方向" + speedDirection[timercount] + "度");
            HDirectionShow.Text = ("船首方向" + headingDirection[timercount] + "度");
            SpeedShow.Text = ("速度" + speed[timercount] + "節");
        }
        private float[][] sDirection(float x, float y)
        {
            float[][] resultoutput = MatrixCreate(1, 2);
            resultoutput[0][0] = x + (float)(0.005 * Math.Cos((-1f * ((speedDirection[dataread]) / 365.0) * 2 * Math.PI) + 0.5 * Math.PI));
            resultoutput[0][1] = y + (float)(0.005 * Math.Sin((-1f * ((speedDirection[dataread]) / 365.0) * 2 * Math.PI) + 0.5 * Math.PI));
            return resultoutput;
        }
        private float[][] hDirection(float x, float y)
        {
            float[][] resultoutput = MatrixCreate(1, 2);
            resultoutput[0][0] = x + (float)(0.005 * Math.Cos((-1f * ((headingDirection[dataread]) / 365.0) * 2 * Math.PI) + 0.5 * Math.PI));
            resultoutput[0][1] = y + (float)(0.005 * Math.Sin((-1f * ((headingDirection[dataread]) / 365.0) * 2 * Math.PI) + 0.5 * Math.PI));
            return resultoutput;
        }
        private void ReceiveButton_Click(object sender, EventArgs e)
        {

            _GraphicsDirection.Clear(Color.FromArgb(0, 255, 255, 255));
            timer1.Enabled = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timercount < datacount && timercount != 0)
            {
                //_Graphics.Clear(Color.White);
                _GraphicsDirection.Clear(Color.FromArgb(0, 255, 255, 255));
                xx1 = xx[timercount];
                yy1 = yy[timercount];
                xx2 = xx[timercount - 1];
                yy2 = yy[timercount - 1];
                _Graphics.DrawLine(mypen, xx1, yy1, xx2, yy2);
                DotDraw();
                LabelChange();
                //graphics.Clear(Color.White);
                graphics.DrawImage(_image, new Point(0, 0));
                sxx = sXX[timercount];
                syy = sYY[timercount];
                _GraphicsDirection.DrawLine(Sdirectionpen, xx1, yy1, sxx, syy);
                hxx = hXX[timercount];
                hyy = hYY[timercount];
                _GraphicsDirection.DrawLine(Hdirectionpen, xx1, yy1, hxx, hyy);
                grachicsDirection.DrawImage(_imageDirection, new Point(0, 0));
                timercount++;
            }
            else if (timercount == 0)
            {

                graphics.DrawImage(_image, new Point(0, 0));
                xx1 = xx[timercount];
                yy1 = yy[timercount];
                DotDraw();
                LabelChange();
                sxx = sXX[timercount];
                syy = sYY[timercount];
                _GraphicsDirection.DrawLine(Sdirectionpen, xx1, yy1, sxx, syy);
                hxx = hXX[timercount];
                hyy = hYY[timercount];
                _GraphicsDirection.DrawLine(Hdirectionpen, xx1, yy1, hxx, hyy);
                graphics.DrawImage(_image, new Point(0, 0));
                grachicsDirection.DrawImage(_imageDirection, new Point(0, 0));
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

        private void ZoomInButton_Click(object sender, EventArgs e)
        {
            if (ZoomRatio < 1.5 && timercount + 1 < datacount)
            {
                timer1.Enabled = false;
                ZoomRatio += 0.1f;
                xminnow = xcenter - (xcenter - xmin) / ZoomRatio;
                xmaxnow = xcenter + (xmax - xcenter) / ZoomRatio;
                yminnow = ycenter - (ycenter - ymin) / ZoomRatio;
                ymaxnow = ycenter + (ymax - ycenter) / ZoomRatio;
                ShipGenerate();
                _Graphics.Clear(Color.White);
                DotDraw();
                LabelChange();

                for (int i = 0; i < timercount; i++)
                {
                    xx1 = xx[i];
                    yy1 = yy[i];
                    xx2 = xx[i + 1];
                    yy2 = yy[i + 1];
                    _Graphics.DrawLine(mypen, xx1, yy1, xx2, yy2);
                }
                graphics.DrawImage(_image, new Point(0, 0));
                timer1.Enabled = true;

            }
        }

        private void ZoomOutButton_Click(object sender, EventArgs e)
        {
            if (ZoomRatio > 0.5 && timercount + 1 < datacount)
            {
                timer1.Enabled = false;
                ZoomRatio -= 0.1f;
                xminnow = xcenter - (xcenter - xmin) / ZoomRatio;
                xmaxnow = xcenter + (xmax - xcenter) / ZoomRatio;
                yminnow = ycenter - (ycenter - ymin) / ZoomRatio;
                ymaxnow = ycenter + (ymax - ycenter) / ZoomRatio;
                ShipGenerate();
                _Graphics.Clear(Color.White);
                DotDraw();
                LabelChange();
                for (int i = 0; i < timercount; i++)
                {
                    xx1 = xx[i];
                    yy1 = yy[i];
                    xx2 = xx[i + 1];
                    yy2 = yy[i + 1];
                    _Graphics.DrawLine(mypen, xx1, yy1, xx2, yy2);
                }
                graphics.DrawImage(_image, new Point(0, 0));
                timer1.Enabled = true;

            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                timer1.Enabled = false;
                xminnow -= (e.X - xPos) * 0.0005f;
                xmaxnow -= (e.X - xPos) * 0.0005f;
                yminnow += (e.Y - yPos) * 0.0005f;
                ymaxnow += (e.Y - yPos) * 0.0005f;
                ShipGenerate();
                _Graphics.Clear(Color.White);
                graphics.Clear(Color.White);
                for (int i = 0; i < timercount; i++)
                {
                    xx1 = xx[i];
                    yy1 = yy[i];
                    xx2 = xx[i + 1];
                    yy2 = yy[i + 1];
                    _Graphics.DrawLine(mypen, xx1, yy1, xx2, yy2);
                    DotDraw();
                    LabelChange();
                }
                graphics.DrawImage(_image, new Point(0, 0));
                timer1.Enabled = true;
                Thread.Sleep(100);
            }

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {

            xPos = e.X;//當前X座標
            yPos = e.Y;//當前Y座標
        }
    }
}