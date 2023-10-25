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
using OBSGL_DecodeLibrary;
using WinformTCPClient;

namespace WinformTCPClient
{
    public partial class Form2 : Form
    {

        //畫布畫筆相關參數開始
        Image _image = null;//用於存放繪圖內容的中間載體image
        Graphics _Graphics = null;//在image上繪圖的畫布，不可見        
        Pen mypen = null;//畫筆
        Pen dotpen = null;
        Graphics graphics = null;//窗體上繪圖的畫布，可見
        Image _imageDirection = null;
        Graphics _GraphicsDirection = null;
        Graphics grachicsDirection = null;
        Image _imageSub = null;
        Graphics _GraphicsSub = null;
        Graphics grachicsSub = null;
        Pen Sdirectionpen = null;
        Pen Hdirectionpen = null;
        Pen Subpen = null;
        //畫布畫筆相關參數結束

        //計算座標相關參數開始
        float formHeight;
        float formWidth;
        float xmin = (float)-2000;
        float xmax = (float)2000;
        float ymin = (float)-2000;
        float ymax = (float)2000;
        float xminnow, xmaxnow, yminnow, ymaxnow;
        double xbase = 177856.2331;
        double ybase = 2494369.982;
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

        //障礙船資料儲存開始
        List<OBSGL_Decode.ObjectionData> objDraw = new List<OBSGL_Decode.ObjectionData>();
        float subxx;
        float subyy;
        float[][] subresult = DrawShip.MatrixCreate(1, 2);
        float[][] subresultDirection = DrawShip.MatrixCreate(1, 2);
        int subflag = 0;
        //障礙船資料儲存結束
        public static StreamWriter sw = new StreamWriter("E:\\Practice\\WinformTCPClient\\SpeedAndHeading.csv");
        int firstData = 1;

        public Form2()
        {
            InitializeComponent();
            DrawInitialize();
            var MaindataReceive = new Task(MainDataReceive);
            MaindataReceive.Start();
            var SubdataReceive = new Task(SubDataReceive);
            SubdataReceive.Start();
        }
        private void DrawInitialize()
        {
            _image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            _imageDirection = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            _imageSub = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            _Graphics = Graphics.FromImage(_image);//_Graphics是_image的畫布，將畫圖信息存在_image內
            _GraphicsDirection = Graphics.FromImage(_imageDirection);
            _GraphicsSub = Graphics.FromImage(_imageSub);
            mypen = new Pen(Color.Red, 3);
            dotpen = new Pen(Color.Gray);//畫筆
            Subpen = new Pen(Color.Blue,10);
            dotpen.DashPattern = new float[] { 10.0F, 2.0F };
            Sdirectionpen = new Pen(Color.Blue, 3);
            Hdirectionpen = new Pen(Color.Green, 3);
            graphics = pictureBox1.CreateGraphics();//graphics為視窗畫布，用來顯示繪圖信息
            grachicsDirection = pictureBox1.CreateGraphics();
            grachicsSub = pictureBox1.CreateGraphics();
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
            _GraphicsSub.Clear(Color.FromArgb(0, 255, 255, 255));
        }
        public void MainDataReceive()
        {
            while (true)
            {
                
                if (Form1.MaindrawFlag == 1)
                {
                    if (firstData == 1 && NEMA0183DecodeLibrary.NEMA0183DecodeLibrary.DT[NEMA0183DecodeLibrary.NEMA0183DecodeLibrary.RMCstartFlag].lat !=0 )
                    {
                        firstData = 0;
                        xbase = NEMA0183DecodeLibrary.NEMA0183DecodeLibrary.DT[NEMA0183DecodeLibrary.NEMA0183DecodeLibrary.RMCstartFlag].lat;
                        ybase = NEMA0183DecodeLibrary.NEMA0183DecodeLibrary.DT[NEMA0183DecodeLibrary.NEMA0183DecodeLibrary.RMCstartFlag].lon;
                    }
                    dataChange[endflag].lat = NEMA0183DecodeLibrary.NEMA0183DecodeLibrary.DT[NEMA0183DecodeLibrary.NEMA0183DecodeLibrary.RMCstartFlag].lat - xbase;
                    dataChange[endflag].lon = NEMA0183DecodeLibrary.NEMA0183DecodeLibrary.DT[NEMA0183DecodeLibrary.NEMA0183DecodeLibrary.RMCstartFlag].lon - ybase;
                    dataChange[endflag].speed = NEMA0183DecodeLibrary.NEMA0183DecodeLibrary.DT[NEMA0183DecodeLibrary.NEMA0183DecodeLibrary.RMCstartFlag].speed;
                    dataChange[endflag].speedDirection = NEMA0183DecodeLibrary.NEMA0183DecodeLibrary.DT[NEMA0183DecodeLibrary.NEMA0183DecodeLibrary.RMCstartFlag].sDirection;
                    dataChange[endflag].headingDirection = NEMA0183DecodeLibrary.NEMA0183DecodeLibrary.DT[NEMA0183DecodeLibrary.NEMA0183DecodeLibrary.RMCstartFlag].hDirection;
                    
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
                    Form1.MaindrawFlag = 0;
                    NEMA0183DecodeLibrary.NEMA0183DecodeLibrary.HDTstartFlag++;
                    NEMA0183DecodeLibrary.NEMA0183DecodeLibrary.RMCstartFlag++;
                    shipflag = 1;
                }
            }
        }
        private void SubDataReceive()
        {
            while (true)
            {
                if (Form1.SubdrawFlag == 1)
                {
                    objDraw.Clear();
                    TransferALL(OBSGL_Decode.obj, objDraw);
                    Form1.SubdrawFlag = 0;
                    subflag = 1;
                    OBSGL_Decode.obj.Clear();
                }
            }
        }
        private void TransferALL(List<OBSGL_Decode.ObjectionData> fromList, List<OBSGL_Decode.ObjectionData> toList)
        {
            toList.AddRange(fromList);
        }
        public void ShipGenerate()
        {
            drawflag = endflag - 1;
            if (drawflag > 0 && shipflag == 1)
            {
                xx = (float)dataChange[drawflag].lat;
                yy = (float)dataChange[drawflag].lon;
                speed = (float)dataChange[drawflag].speed;
                speedDirection = -1f*((float)dataChange[drawflag].speedDirection)+90f;
                headingDirection = -1f*((float)dataChange[drawflag].headingDirection)+90f;
                if (speedDirection<0) 
                {
                    speedDirection += 360;
                }
                if (headingDirection<0) 
                {
                    headingDirection += 360;
                }
                CPA_TCPAcount();
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
        private void SubGenerate()
        {
            if (subflag == 1 && firstData == 0)
            {
                _GraphicsSub.Clear(Color.FromArgb(0, 255, 255, 255));
                foreach (OBSGL_Decode.ObjectionData objectionData in objDraw)
                {
                    subxx = (float)((objectionData.xX) + 177856.2331f - (float)xbase);
                    subyy = (float)((objectionData.yY) + 2494369.982f - (float)ybase);
                    result = DrawShip.CT(subxx, subyy, xminnow, xmaxnow, yminnow, ymaxnow, formWidth, formHeight);
                    subxx = result[0][0];
                    subyy = result[0][1];
                    _GraphicsSub.DrawEllipse(Subpen, subxx, subyy, 0.1f, 0.1f);
                }
                grachicsSub.DrawImage(_imageSub, new Point(0, 0));
                subflag = 0;
            }

        }
        static (double CPA, double TCPA) CalculateCPAandTCPA(Ship ship1, Ship ship2)
        {
            // Convert courses from degrees to radians
            double course1Rad = ship1.Course * Math.PI / 180;
            double course2Rad = ship2.Course * Math.PI / 180;

            // Calculate velocity components for each ship
            double vx1 = ship1.Speed * Math.Cos(course1Rad);
            double vy1 = ship1.Speed * Math.Sin(course1Rad);
            double vx2 = ship2.Speed * Math.Cos(course2Rad);
            double vy2 = ship2.Speed * Math.Sin(course2Rad);

            // Calculate relative velocity
            double vx = vx2 - vx1;
            double vy = vy2 - vy1;

            // Calculate relative position
            double dx = ship2.X - ship1.X;
            double dy = ship2.Y - ship1.Y;

            // Calculate time to CPA
            double tcpa = -(dx * vx + dy * vy) / (vx * vx + vy * vy);

            // Calculate positions of ships at CPA
            double x1 = ship1.X + vx1 * tcpa;
            double y1 = ship1.Y + vy1 * tcpa;
            double x2 = ship2.X + vx2 * tcpa;
            double y2 = ship2.Y + vy2 * tcpa;

            // Calculate CPA
            double cpa = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));

            return (cpa, tcpa);
        }
        private void CPA_TCPAcount() 
        {
            if ( objDraw != null ) 
            {
                textBox1.Text = null;
                sw.Write($"{xx},{yy},{speedDirection},{headingDirection}");
                foreach (OBSGL_Decode.ObjectionData obj in objDraw) 
                {
                    float v = (float)Math.Sqrt(Math.Pow(obj.sX,2)+Math.Pow(obj.sY,2));
                    float anglev =  (float)Math.Atan2(obj.sY,obj.sX)+headingDirection;
                    Ship ship1 = new Ship(xx, yy, 0, headingDirection);
                    Ship ship2 = new Ship((obj.xX-(float)xbase), (obj.yY-(float)ybase),v, anglev);
                    var (cpa, tcpa) = CalculateCPAandTCPA(ship1, ship2);
                    textBox1.Text += ($"ID: {obj.ID}, DCPA:{cpa.ToString("#0.000")} meter, TCPA:{tcpa.ToString("#0.000")} seconds. \r\n");
                    sw.Write($"{obj.ID},{(obj.xX - (float)xbase)},{(obj.yY - (float)ybase)},{v},{anglev},{cpa},{tcpa}");
                }
                sw.Write("\n");
            }
        }

        private void ReceiveButton_Click(object sender, EventArgs e)
        {
            _GraphicsDirection.Clear(Color.FromArgb(0, 255, 255, 255));


        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            ShipGenerate();
            SubGenerate();
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
            Form1 f = new Form1();
            this.Visible = false;
            f.Visible = true;
        }

        private void ZoomInButton_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            ZoomRatio += 0.5f;
            xminnow = xcenter - (xcenter - xmin) / ZoomRatio;
            xmaxnow = xcenter + (xmax - xcenter) / ZoomRatio;
            yminnow = ycenter - (ycenter - ymin) / ZoomRatio;
            ymaxnow = ycenter + (ymax - ycenter) / ZoomRatio;
            ShipRegenerate();
            timer1.Enabled = true;
        }

        private void ZoomOutButton_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            ZoomRatio -= 0.5f;
            xminnow = xcenter - (xcenter - xmin) / ZoomRatio;
            xmaxnow = xcenter + (xmax - xcenter) / ZoomRatio;
            yminnow = ycenter - (ycenter - ymin) / ZoomRatio;
            ymaxnow = ycenter + (ymax - ycenter) / ZoomRatio;
            ShipRegenerate();
            timer1.Enabled = true;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                timer1.Enabled = false;
                xminnow -= (e.X - xPos) * 1f;
                xmaxnow -= (e.X - xPos) * 1f;
                yminnow += (e.Y - yPos) * 1f;
                ymaxnow += (e.Y - yPos) * 1f;
                xcenter -= (e.X - xPos) * 1f;
                ycenter += (e.Y - yPos) * 1f;
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
