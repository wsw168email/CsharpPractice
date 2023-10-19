using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NEMA0183DecodeLibrary;
using WinformTCPClient;

namespace WinformTCPClient
{
    public partial class Form2 : Form
    {

        int datacount = 0;
        int timercount = 0;
        int dataread = 0;
        //畫布畫筆相關參數開始
        Image _image = null;//用於存放繪圖內容的中間載體image
        Graphics _Graphics = null;//在image上繪圖的畫布，不可見        
        Pen mypen = null;//畫筆
        Pen dotpen = null;
        Graphics graphics = null;//窗體上繪圖的畫布，可見
        Image _imageDirection = null;
        Graphics _GraphicsDirection = null;
        Graphics grachicsDirection = null;
        Pen Sdirectionpen = null;
        Pen Hdirectionpen = null;
        //畫布畫筆相關參數結束

        //計算座標相關參數開始
        float formHeight;
        float formWidth;
        float xmin = (float)0.2;
        float xmax = (float)0.4;
        float ymin = (float)0.2;
        float ymax = (float)0.4;
        float xminnow, xmaxnow, yminnow, ymaxnow;
        double xbase = 177698;
        double ybase = 2500798;
        float xcenter, ycenter;
        float ZoomRatio = 1.0f;
        private int xPos;
        private int yPos;
        float[][] result = DrawShip.MatrixCreate(1, 2);
        float[][] resultDirection = DrawShip.MatrixCreate(1, 2);
        //計算座標相關參數結束

        //紀錄座標相關參數開始
        float xx;
        float yy;
        float speed;
        float speedDirection;
        float headingDirection;
        float sXX;
        float sYY;
        float hXX;
        float hYY;
        //紀錄座標相關參數結束

        //Circle Stack相關參數設定開始
        struct datachange
        {
            public double lon;
            public double lat;
            public float speed;
            public float speedDirection;
            public float headingDirection;
        }
        datachange[] dataChange = new datachange[300];
        int startflag = 0;
        int endflag = 0;
        int drawflag = 0; //畫的位置,避免時間不同步造成一直畫最新儲存格
        int shipflag = 0; //避免重複畫同個位置
        int reshapeflag = 0; //開始重新繪製縮放後的位置
        //Circle Stack相關參數設定結束


        public Form2()
        {
            InitializeComponent();
            DrawInitialize();
            var dataReceive = new Task(DataReceive);
            dataReceive.Start();
        }
        private void DrawInitialize()
        {
            _image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            _imageDirection = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            _Graphics = Graphics.FromImage(_image);//_Graphics是_image的畫布，將畫圖信息存在_image內
            _GraphicsDirection = Graphics.FromImage(_imageDirection);
            mypen = new Pen(Color.Red, 3);
            dotpen = new Pen(Color.Gray);//畫筆
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
            timer1.Enabled = true;
            xcenter = (xmax - xmin) * 0.5f + xmin;
            ycenter = (ymax - ymin) * 0.5f + ymin;
            _Graphics.Clear(Color.White);
            _GraphicsDirection.Clear(Color.FromArgb(0, 255, 255, 255));
        }
        public void DataReceive()
        {
            while (true)
            {
                if (Form1.drawFlag == 1)
                {
                    dataChange[endflag].lat = NEMA0183DecodeLibrary.NEMA0183DecodeLibrary.DT.lat - xbase;
                    dataChange[endflag].lon = NEMA0183DecodeLibrary.NEMA0183DecodeLibrary.DT.lon - ybase;
                    dataChange[endflag].speed = NEMA0183DecodeLibrary.NEMA0183DecodeLibrary.DT.speed;
                    dataChange[endflag].speedDirection = NEMA0183DecodeLibrary.NEMA0183DecodeLibrary.DT.sDirection;
                    dataChange[endflag].headingDirection = NEMA0183DecodeLibrary.NEMA0183DecodeLibrary.DT.hDirection;
                    endflag++;
                    if (endflag == dataChange.Length)
                    {
                        endflag = 0;
                    }
                    if (endflag == startflag)
                    {
                        startflag++;
                    }
                    if (startflag! == dataChange.Length)
                    {
                        startflag = 0;
                    }
                    Form1.drawFlag = 0;
                    shipflag = 1;
                }
            }
        }
        public void ShipGenerate()
        {
            drawflag = endflag-1;
            if (drawflag > 0 && shipflag == 1) 
            {
                xx = (float)dataChange[drawflag].lat;
                yy = (float)dataChange[drawflag].lon;
                speed = (float)dataChange[drawflag].speed;
                speedDirection = (float)dataChange[drawflag].speedDirection;
                headingDirection = (float)dataChange[drawflag].headingDirection;
                result = DrawShip.sDirection(xx, yy, speedDirection);
                resultDirection = DrawShip.CT(result[0][0], result[0][1], xminnow, xmaxnow, yminnow, ymaxnow, formWidth, formHeight);
                sXX = resultDirection[0][0];
                sYY = resultDirection[0][1];
                result = DrawShip.hDirection(xx, yy, headingDirection);
                resultDirection = DrawShip.CT(result[0][0], result[0][1], xminnow, xmaxnow, yminnow, ymaxnow, formWidth, formHeight);
                hXX = resultDirection[0][0];
                hYY = resultDirection[0][1];
                result = DrawShip.CT(xx, yy, xminnow, xmaxnow, yminnow, ymaxnow, formWidth, formHeight);
                xx = result[0][0];
                yy = result[0][1];
                _GraphicsDirection.Clear(Color.FromArgb(0, 255, 255, 255));
                DrawCoordinate.DotDraw(_Graphics, dotpen, formWidth, formHeight);
                DrawShip.LabelChange(xbase, ybase, xminnow, xmaxnow, yminnow, ymaxnow, speedDirection, headingDirection, speed);
                _Graphics.DrawEllipse(mypen, xx, yy, 0.1f, 0.1f);
                graphics.DrawImage(_image, new Point(0, 0));
                _GraphicsDirection.DrawLine(Sdirectionpen, xx, yy, sXX, sYY);
                _GraphicsDirection.DrawLine(Hdirectionpen, xx, yy, hXX, hYY);
                graphics.DrawImage(_image, new Point(0, 0));
                grachicsDirection.DrawImage(_imageDirection, new Point(0, 0));
                shipflag = 0;
            }
            
        }
        public void ShipRegenerate()
        {
            _Graphics.Clear(Color.White);
            graphics.Clear(Color.White);
            DrawCoordinate.DotDraw(_Graphics, dotpen, formWidth, formHeight);
            DrawShip.LabelChange(xbase, ybase, xminnow, xmaxnow, yminnow, ymaxnow, speedDirection, headingDirection, speed);
            reshapeflag = startflag;
            while (reshapeflag != endflag)
            {
                xx = (float)dataChange[reshapeflag].lat;
                yy = (float)dataChange[reshapeflag].lon;
                result = DrawShip.CT(xx, yy, xminnow, xmaxnow, yminnow, ymaxnow, formWidth, formHeight);
                xx = result[0][0];
                yy = result[0][1];
                _Graphics.DrawEllipse(mypen, xx, yy, 0.1f, 0.1f);
                reshapeflag++;
                if (reshapeflag == dataChange.Length)
                {
                    reshapeflag = 0;
                }
            }
            graphics.DrawImage(_image, new Point(0, 0));
        }

        private void ReceiveButton_Click(object sender, EventArgs e)
        {
            _GraphicsDirection.Clear(Color.FromArgb(0, 255, 255, 255));


        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            ShipGenerate();
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
            Form1 f = new Form1();
            this.Visible = false;
            f.Visible = true;
        }

        private void ZoomInButton_Click(object sender, EventArgs e)
        {
            if (ZoomRatio < 1.5)
            {
                timer1.Enabled = false;
                ZoomRatio += 0.1f;
                xminnow = xcenter - (xcenter - xmin) / ZoomRatio;
                xmaxnow = xcenter + (xmax - xcenter) / ZoomRatio;
                yminnow = ycenter - (ycenter - ymin) / ZoomRatio;
                ymaxnow = ycenter + (ymax - ycenter) / ZoomRatio;
                ShipRegenerate();
                timer1.Enabled = true;

            }
        }

        private void ZoomOutButton_Click(object sender, EventArgs e)
        {
            if (ZoomRatio > 0.5)
            {
                timer1.Enabled = false;
                ZoomRatio -= 0.1f;
                xminnow = xcenter - (xcenter - xmin) / ZoomRatio;
                xmaxnow = xcenter + (xmax - xcenter) / ZoomRatio;
                yminnow = ycenter - (ycenter - ymin) / ZoomRatio;
                ymaxnow = ycenter + (ymax - ycenter) / ZoomRatio;
                ShipRegenerate();
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
                ShipRegenerate();
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
