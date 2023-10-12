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

namespace ChartDrawing
{
    public partial class Form1 : Form
    {
        Chart chart;
        int[] xvalue, yvalue;
        int x_tick;
        public Form1()
        {
            InitializeComponent();
            chart = MyChart(500, 300, 0);
            InitXY();
            chart.Series.Add(getSeries());
            Controls.Add(chart);

            // Update when timer ticks
            Timer timer = new Timer();
            timer.Interval = 1000;      // 1 second
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        public Chart MyChart(int width, int height, int value)
        {
            Chart chart = new Chart();
            chart.Width = width;
            chart.Height = height;
            chart.Location = new Point(0, 0);
            chart.Visible = true;

            ChartArea ca = new ChartArea("My Chart");
            ca.BackColor = Color.Azure;
            ca.BackGradientStyle = GradientStyle.HorizontalCenter;
            ca.BackHatchStyle = ChartHatchStyle.LargeGrid;
            ca.ShadowColor = Color.Purple;
            ca.ShadowOffset = 0;

            ca.AxisY.Enabled = AxisEnabled.True;
            ca.AxisY.LineColor = Color.LightBlue;
            ca.AxisY2.LabelStyle.Enabled = true;
            ca.AxisY2.LineColor = Color.LightBlue;
            ca.AxisY.Minimum = 0;                                   //Y axis Minimum value

            ca.AxisX.Title = value + " unit / sec";
            ca.AxisX.Interval = 5;
            ca.AxisX.LabelAutoFitMinFontSize = 5;
            ca.AxisX.LabelStyle.Angle = -20;
            ca.AxisX.LabelStyle.IsEndLabelVisible = true;           //show the last label
            ca.AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
            ca.AxisX.IntervalType = DateTimeIntervalType.NotSet;
            ca.AxisX.TextOrientation = TextOrientation.Auto;
            ca.AxisX.LineWidth = 1;
            ca.AxisX.LineColor = Color.LightBlue;
            ca.AxisX.Enabled = AxisEnabled.True;
            ca.AxisX.ScaleView.MinSizeType = DateTimeIntervalType.Seconds;
            ca.AxisX.ScrollBar = new AxisScrollBar();

            chart.ChartAreas.Add(ca);
            chart.ChartAreas[0].Axes[0].MajorGrid.Enabled = false;  //x axis
            chart.ChartAreas[0].Axes[1].MajorGrid.Enabled = false;  //y axis
            chart.ChartAreas[0].AxisX.IsMarginVisible = false;
            return chart;
        }
        public void InitXY()
        {
            x_tick = 20;
            xvalue = new int[x_tick];
            yvalue = new int[x_tick];
            for (int i = 0; i < x_tick; i++)
            {
                xvalue[i] = i;
                yvalue[i] = 0;
            }
        }
        public Series getSeries()
        {
            Series series = new Series();
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 2;
            series.Color = Color.OrangeRed;
            series.XValueType = ChartValueType.Int32;
            series.YValueType = ChartValueType.Int32;
            series.IsValueShownAsLabel = false;

            for (int i = 0; i < x_tick; i++)
            {
                series.Points.AddXY(xvalue[i], yvalue[i]);
            }

            return series;
        }



        private void timer_Tick(object sender, EventArgs e)
        {
            Random rand = new Random();
            for (int i = 1; i < x_tick; i++)
            {
                xvalue[i - 1] = xvalue[i];
                yvalue[i - 1] = yvalue[i];
            }

            int current_yvalue = rand.Next(100);
            xvalue[x_tick - 1]++;
            yvalue[x_tick - 1] = current_yvalue;

            chart.Visible = false;
            Controls.Remove(chart);
            chart = MyChart(600, 400, current_yvalue);
            chart.Series.Add(getSeries());
            this.Controls.Add(chart);
        }
    }
}
