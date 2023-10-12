using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ChartDrawing2
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // 設定ChartArea
            ChartArea chtArea = new ChartArea("ViewArea");
            chtArea.AxisX.Minimum = 0; //X軸數值從0開始
            chtArea.AxisX.ScaleView.Size = 10; //設定視窗範圍內一開始顯示多少點
            chtArea.AxisX.Interval = 5;
            chtArea.AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
            chtArea.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All; //設定scrollbar
            chart1.ChartAreas[0] = chtArea; // chart new 出來時就有內建第一個chartarea

            // 設定 Timer
            Timer clsTimer = new Timer();
            clsTimer.Tick += new EventHandler(RefreshChart);
            clsTimer.Interval = 300;
            clsTimer.Start();
        }
        private int m_nTimeCount = 0;
        Random clsRanom = new Random();
        private void RefreshChart(object sender, EventArgs e)
        {
            // 新增一個點至Series中
            chart1.Series[0].Points.AddXY(m_nTimeCount, clsRanom.Next(0, 100));
            if (m_nTimeCount > 10)
            {
                chart1.ChartAreas[0].AxisX.ScaleView.Position = m_nTimeCount - 10; //將視窗焦點維持在最新的點那邊
            }
            m_nTimeCount++;
        }
    }
}
