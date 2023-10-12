namespace DrawPractice2
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
            StopButton = new Button();
            PauseButton = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1168, 1168);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += pictureBox1_Paint;
            // 
            // ReceiveButton
            // 
            ReceiveButton.Location = new Point(102, 1295);
            ReceiveButton.Name = "ReceiveButton";
            ReceiveButton.Size = new Size(150, 46);
            ReceiveButton.TabIndex = 3;
            ReceiveButton.Text = "Receive";
            ReceiveButton.UseVisualStyleBackColor = true;
            ReceiveButton.Click += ReceiveButton_Click;
            // 
            // StopButton
            // 
            StopButton.Location = new Point(798, 1295);
            StopButton.Name = "StopButton";
            StopButton.Size = new Size(150, 46);
            StopButton.TabIndex = 4;
            StopButton.Text = "Stop";
            StopButton.UseVisualStyleBackColor = true;
            StopButton.Click += StopButton_Click;
            // 
            // PauseButton
            // 
            PauseButton.Location = new Point(464, 1295);
            PauseButton.Name = "PauseButton";
            PauseButton.Size = new Size(150, 46);
            PauseButton.TabIndex = 5;
            PauseButton.Text = "Pause";
            PauseButton.UseVisualStyleBackColor = true;
            PauseButton.Click += PauseButton_Click;
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
            Controls.Add(PauseButton);
            Controls.Add(StopButton);
            Controls.Add(ReceiveButton);
            Controls.Add(pictureBox1);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pictureBox1;
        private Button ReceiveButton;
        private Button StopButton;
        private Button PauseButton;
        private System.Windows.Forms.Timer timer1;
    }
}