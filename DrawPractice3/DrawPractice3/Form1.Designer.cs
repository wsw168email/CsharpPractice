namespace DrawPractice3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pictureBox1 = new PictureBox();
            ReceiveButton = new Button();
            PauseButton = new Button();
            StopButton = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            labelX0 = new Label();
            labelX1 = new Label();
            labelX2 = new Label();
            labelX3 = new Label();
            labelX4 = new Label();
            labelX5 = new Label();
            labelX6 = new Label();
            labelX7 = new Label();
            labelX8 = new Label();
            labelX9 = new Label();
            labelY0 = new Label();
            labelY1 = new Label();
            labelY2 = new Label();
            labelY3 = new Label();
            labelY4 = new Label();
            labelY5 = new Label();
            labelY6 = new Label();
            labelY7 = new Label();
            labelY8 = new Label();
            labelY9 = new Label();
            ZoomInButton = new Button();
            ZoomOutButton = new Button();
            SDirectionShow = new Label();
            HDirectionShow = new Label();
            SpeedShow = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(250, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1000, 1000);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            // 
            // ReceiveButton
            // 
            ReceiveButton.Location = new Point(60, 1285);
            ReceiveButton.Name = "ReceiveButton";
            ReceiveButton.Size = new Size(150, 46);
            ReceiveButton.TabIndex = 1;
            ReceiveButton.Text = "Receive";
            ReceiveButton.UseVisualStyleBackColor = true;
            ReceiveButton.Click += ReceiveButton_Click;
            // 
            // PauseButton
            // 
            PauseButton.Location = new Point(536, 1285);
            PauseButton.Name = "PauseButton";
            PauseButton.Size = new Size(150, 46);
            PauseButton.TabIndex = 2;
            PauseButton.Text = "Pause";
            PauseButton.UseVisualStyleBackColor = true;
            PauseButton.Click += PauseButton_Click;
            // 
            // StopButton
            // 
            StopButton.Location = new Point(1041, 1285);
            StopButton.Name = "StopButton";
            StopButton.Size = new Size(150, 46);
            StopButton.TabIndex = 3;
            StopButton.Text = "Stop";
            StopButton.UseVisualStyleBackColor = true;
            StopButton.Click += StopButton_Click;
            // 
            // timer1
            // 
            timer1.Interval = 200;
            timer1.Tick += timer1_Tick;
            // 
            // labelX0
            // 
            labelX0.AutoSize = true;
            labelX0.Location = new Point(186, 1020);
            labelX0.Name = "labelX0";
            labelX0.Size = new Size(0, 30);
            labelX0.TabIndex = 4;
            // 
            // labelX1
            // 
            labelX1.AutoSize = true;
            labelX1.Location = new Point(286, 1070);
            labelX1.Name = "labelX1";
            labelX1.Size = new Size(0, 30);
            labelX1.TabIndex = 5;
            // 
            // labelX2
            // 
            labelX2.AutoSize = true;
            labelX2.Location = new Point(386, 1020);
            labelX2.Name = "labelX2";
            labelX2.Size = new Size(0, 30);
            labelX2.TabIndex = 6;
            // 
            // labelX3
            // 
            labelX3.AutoSize = true;
            labelX3.Location = new Point(486, 1070);
            labelX3.Name = "labelX3";
            labelX3.Size = new Size(0, 30);
            labelX3.TabIndex = 7;
            // 
            // labelX4
            // 
            labelX4.AutoSize = true;
            labelX4.Location = new Point(586, 1020);
            labelX4.Name = "labelX4";
            labelX4.Size = new Size(0, 30);
            labelX4.TabIndex = 8;
            // 
            // labelX5
            // 
            labelX5.AutoSize = true;
            labelX5.Location = new Point(686, 1070);
            labelX5.Name = "labelX5";
            labelX5.Size = new Size(0, 30);
            labelX5.TabIndex = 9;
            // 
            // labelX6
            // 
            labelX6.AutoSize = true;
            labelX6.Location = new Point(786, 1020);
            labelX6.Name = "labelX6";
            labelX6.Size = new Size(0, 30);
            labelX6.TabIndex = 10;
            // 
            // labelX7
            // 
            labelX7.AutoSize = true;
            labelX7.Location = new Point(886, 1070);
            labelX7.Name = "labelX7";
            labelX7.Size = new Size(0, 30);
            labelX7.TabIndex = 11;
            // 
            // labelX8
            // 
            labelX8.AutoSize = true;
            labelX8.Location = new Point(986, 1020);
            labelX8.Name = "labelX8";
            labelX8.Size = new Size(0, 30);
            labelX8.TabIndex = 12;
            // 
            // labelX9
            // 
            labelX9.AutoSize = true;
            labelX9.Location = new Point(1086, 1070);
            labelX9.Name = "labelX9";
            labelX9.Size = new Size(0, 30);
            labelX9.TabIndex = 13;
            // 
            // labelY0
            // 
            labelY0.AutoSize = true;
            labelY0.Location = new Point(60, 980);
            labelY0.Name = "labelY0";
            labelY0.Size = new Size(0, 30);
            labelY0.TabIndex = 14;
            // 
            // labelY1
            // 
            labelY1.AutoSize = true;
            labelY1.Location = new Point(60, 880);
            labelY1.Name = "labelY1";
            labelY1.Size = new Size(0, 30);
            labelY1.TabIndex = 15;
            // 
            // labelY2
            // 
            labelY2.AutoSize = true;
            labelY2.Location = new Point(60, 780);
            labelY2.Name = "labelY2";
            labelY2.Size = new Size(0, 30);
            labelY2.TabIndex = 16;
            // 
            // labelY3
            // 
            labelY3.AutoSize = true;
            labelY3.Location = new Point(60, 680);
            labelY3.Name = "labelY3";
            labelY3.Size = new Size(0, 30);
            labelY3.TabIndex = 17;
            // 
            // labelY4
            // 
            labelY4.AutoSize = true;
            labelY4.Location = new Point(60, 580);
            labelY4.Name = "labelY4";
            labelY4.Size = new Size(0, 30);
            labelY4.TabIndex = 18;
            // 
            // labelY5
            // 
            labelY5.AutoSize = true;
            labelY5.Location = new Point(60, 480);
            labelY5.Name = "labelY5";
            labelY5.Size = new Size(0, 30);
            labelY5.TabIndex = 19;
            // 
            // labelY6
            // 
            labelY6.AutoSize = true;
            labelY6.Location = new Point(60, 380);
            labelY6.Name = "labelY6";
            labelY6.Size = new Size(0, 30);
            labelY6.TabIndex = 20;
            // 
            // labelY7
            // 
            labelY7.AutoSize = true;
            labelY7.Location = new Point(60, 280);
            labelY7.Name = "labelY7";
            labelY7.Size = new Size(0, 30);
            labelY7.TabIndex = 21;
            // 
            // labelY8
            // 
            labelY8.AutoSize = true;
            labelY8.Location = new Point(60, 180);
            labelY8.Name = "labelY8";
            labelY8.Size = new Size(0, 30);
            labelY8.TabIndex = 22;
            // 
            // labelY9
            // 
            labelY9.AutoSize = true;
            labelY9.Location = new Point(60, 80);
            labelY9.Name = "labelY9";
            labelY9.Size = new Size(0, 30);
            labelY9.TabIndex = 23;
            // 
            // ZoomInButton
            // 
            ZoomInButton.Location = new Point(60, 1362);
            ZoomInButton.Name = "ZoomInButton";
            ZoomInButton.Size = new Size(150, 46);
            ZoomInButton.TabIndex = 24;
            ZoomInButton.Text = "Zoom In";
            ZoomInButton.UseVisualStyleBackColor = true;
            ZoomInButton.Click += ZoomInButton_Click;
            // 
            // ZoomOutButton
            // 
            ZoomOutButton.Location = new Point(236, 1362);
            ZoomOutButton.Name = "ZoomOutButton";
            ZoomOutButton.Size = new Size(150, 46);
            ZoomOutButton.TabIndex = 25;
            ZoomOutButton.Text = "Zoom Out";
            ZoomOutButton.UseVisualStyleBackColor = true;
            ZoomOutButton.Click += ZoomOutButton_Click;
            // 
            // SDirectionShow
            // 
            SDirectionShow.AutoSize = true;
            SDirectionShow.Location = new Point(686, 1353);
            SDirectionShow.Name = "SDirectionShow";
            SDirectionShow.Size = new Size(0, 30);
            SDirectionShow.TabIndex = 26;
            // 
            // HDirectionShow
            // 
            HDirectionShow.AutoSize = true;
            HDirectionShow.Location = new Point(686, 1390);
            HDirectionShow.Name = "HDirectionShow";
            HDirectionShow.Size = new Size(0, 30);
            HDirectionShow.TabIndex = 27;
            // 
            // SpeedShow
            // 
            SpeedShow.AutoSize = true;
            SpeedShow.Location = new Point(986, 1353);
            SpeedShow.Name = "SpeedShow";
            SpeedShow.Size = new Size(0, 30);
            SpeedShow.TabIndex = 28;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(14F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1274, 1429);
            Controls.Add(SpeedShow);
            Controls.Add(HDirectionShow);
            Controls.Add(SDirectionShow);
            Controls.Add(ZoomOutButton);
            Controls.Add(ZoomInButton);
            Controls.Add(labelY9);
            Controls.Add(labelY8);
            Controls.Add(labelY7);
            Controls.Add(labelY6);
            Controls.Add(labelY5);
            Controls.Add(labelY4);
            Controls.Add(labelY3);
            Controls.Add(labelY2);
            Controls.Add(labelY1);
            Controls.Add(labelY0);
            Controls.Add(labelX9);
            Controls.Add(labelX8);
            Controls.Add(labelX7);
            Controls.Add(labelX6);
            Controls.Add(labelX5);
            Controls.Add(labelX4);
            Controls.Add(labelX3);
            Controls.Add(labelX2);
            Controls.Add(labelX1);
            Controls.Add(labelX0);
            Controls.Add(StopButton);
            Controls.Add(PauseButton);
            Controls.Add(ReceiveButton);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button ReceiveButton;
        private Button PauseButton;
        private Button StopButton;
        private System.Windows.Forms.Timer timer1;
        private Label labelX0;
        private Label labelX1;
        private Label labelX2;
        private Label labelX3;
        private Label labelX4;
        private Label labelX5;
        private Label labelX6;
        private Label labelX7;
        private Label labelX8;
        private Label labelX9;
        private Label labelY0;
        private Label labelY1;
        private Label labelY2;
        private Label labelY3;
        private Label labelY4;
        private Label labelY5;
        private Label labelY6;
        private Label labelY7;
        private Label labelY8;
        private Label labelY9;
        private Button ZoomInButton;
        private Button ZoomOutButton;
        private Label SDirectionShow;
        private Label HDirectionShow;
        private Label SpeedShow;
    }
}