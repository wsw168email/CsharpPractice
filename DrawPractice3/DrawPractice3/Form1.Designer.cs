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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1174, 1174);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // ReceiveButton
            // 
            ReceiveButton.Location = new Point(43, 1285);
            ReceiveButton.Name = "ReceiveButton";
            ReceiveButton.Size = new Size(150, 46);
            ReceiveButton.TabIndex = 1;
            ReceiveButton.Text = "Receive";
            ReceiveButton.UseVisualStyleBackColor = true;
            ReceiveButton.Click += ReceiveButton_Click;
            // 
            // PauseButton
            // 
            PauseButton.Location = new Point(467, 1285);
            PauseButton.Name = "PauseButton";
            PauseButton.Size = new Size(150, 46);
            PauseButton.TabIndex = 2;
            PauseButton.Text = "Pause";
            PauseButton.UseVisualStyleBackColor = true;
            PauseButton.Click += PauseButton_Click;
            // 
            // StopButton
            // 
            StopButton.Location = new Point(942, 1285);
            StopButton.Name = "StopButton";
            StopButton.Size = new Size(150, 46);
            StopButton.TabIndex = 3;
            StopButton.Text = "Stop";
            StopButton.UseVisualStyleBackColor = true;
            StopButton.Click += StopButton_Click;
            // 
            // timer1
            // 
            timer1.Interval = 50;
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(14F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1174, 1429);
            Controls.Add(StopButton);
            Controls.Add(PauseButton);
            Controls.Add(ReceiveButton);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button ReceiveButton;
        private Button PauseButton;
        private Button StopButton;
        private System.Windows.Forms.Timer timer1;
    }
}