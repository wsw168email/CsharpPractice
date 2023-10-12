namespace MathQuiz
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
            timeLabel = new Label();
            TimeLeft = new Label();
            plusLeftLabel = new Label();
            label1 = new Label();
            plusRightLabel = new Label();
            label3 = new Label();
            sum = new NumericUpDown();
            difference = new NumericUpDown();
            label2 = new Label();
            minusRightLabel = new Label();
            label5 = new Label();
            minusLeftLabel = new Label();
            product = new NumericUpDown();
            label7 = new Label();
            timesRightLabel = new Label();
            label9 = new Label();
            timesLeftLabel = new Label();
            quotient = new NumericUpDown();
            label11 = new Label();
            dividedRightLabel = new Label();
            label13 = new Label();
            dividedLeftLabel = new Label();
            startButton = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)sum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)difference).BeginInit();
            ((System.ComponentModel.ISupportInitialize)product).BeginInit();
            ((System.ComponentModel.ISupportInitialize)quotient).BeginInit();
            SuspendLayout();
            // 
            // timeLabel
            // 
            timeLabel.BorderStyle = BorderStyle.FixedSingle;
            timeLabel.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            timeLabel.Location = new Point(272, 9);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(200, 30);
            timeLabel.TabIndex = 0;
            // 
            // TimeLeft
            // 
            TimeLeft.AutoSize = true;
            TimeLeft.Font = new Font("Microsoft JhengHei UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            TimeLeft.Location = new Point(168, 10);
            TimeLeft.Name = "TimeLeft";
            TimeLeft.Size = new Size(98, 26);
            TimeLeft.TabIndex = 1;
            TimeLeft.Text = "TimeLeft";
            // 
            // plusLeftLabel
            // 
            plusLeftLabel.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            plusLeftLabel.Location = new Point(50, 75);
            plusLeftLabel.Name = "plusLeftLabel";
            plusLeftLabel.Size = new Size(60, 50);
            plusLeftLabel.TabIndex = 2;
            plusLeftLabel.Text = "?";
            plusLeftLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(116, 75);
            label1.Name = "label1";
            label1.Size = new Size(60, 50);
            label1.TabIndex = 3;
            label1.Text = "+";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // plusRightLabel
            // 
            plusRightLabel.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            plusRightLabel.Location = new Point(168, 75);
            plusRightLabel.Name = "plusRightLabel";
            plusRightLabel.Size = new Size(60, 50);
            plusRightLabel.TabIndex = 4;
            plusRightLabel.Text = "?";
            plusRightLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(234, 75);
            label3.Name = "label3";
            label3.Size = new Size(60, 50);
            label3.TabIndex = 5;
            label3.Text = "=";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // sum
            // 
            sum.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            sum.Location = new Point(289, 83);
            sum.Name = "sum";
            sum.Size = new Size(100, 38);
            sum.TabIndex = 1;
            sum.Enter += anwser_Enter;
            // 
            // difference
            // 
            difference.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            difference.Location = new Point(289, 133);
            difference.Name = "difference";
            difference.Size = new Size(100, 38);
            difference.TabIndex = 2;
            difference.Enter += anwser_Enter;
            // 
            // label2
            // 
            label2.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(234, 125);
            label2.Name = "label2";
            label2.Size = new Size(60, 50);
            label2.TabIndex = 10;
            label2.Text = "=";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // minusRightLabel
            // 
            minusRightLabel.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            minusRightLabel.Location = new Point(168, 125);
            minusRightLabel.Name = "minusRightLabel";
            minusRightLabel.Size = new Size(60, 50);
            minusRightLabel.TabIndex = 9;
            minusRightLabel.Text = "?";
            minusRightLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(116, 125);
            label5.Name = "label5";
            label5.Size = new Size(60, 50);
            label5.TabIndex = 8;
            label5.Text = "-";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // minusLeftLabel
            // 
            minusLeftLabel.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            minusLeftLabel.Location = new Point(50, 125);
            minusLeftLabel.Name = "minusLeftLabel";
            minusLeftLabel.Size = new Size(60, 50);
            minusLeftLabel.TabIndex = 7;
            minusLeftLabel.Text = "?";
            minusLeftLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // product
            // 
            product.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            product.Location = new Point(289, 183);
            product.Name = "product";
            product.Size = new Size(100, 38);
            product.TabIndex = 3;
            product.Enter += anwser_Enter;
            // 
            // label7
            // 
            label7.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(234, 175);
            label7.Name = "label7";
            label7.Size = new Size(60, 50);
            label7.TabIndex = 15;
            label7.Text = "=";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timesRightLabel
            // 
            timesRightLabel.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            timesRightLabel.Location = new Point(168, 175);
            timesRightLabel.Name = "timesRightLabel";
            timesRightLabel.Size = new Size(60, 50);
            timesRightLabel.TabIndex = 14;
            timesRightLabel.Text = "?";
            timesRightLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(116, 175);
            label9.Name = "label9";
            label9.Size = new Size(60, 50);
            label9.TabIndex = 13;
            label9.Text = "x";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timesLeftLabel
            // 
            timesLeftLabel.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            timesLeftLabel.Location = new Point(50, 175);
            timesLeftLabel.Name = "timesLeftLabel";
            timesLeftLabel.Size = new Size(60, 50);
            timesLeftLabel.TabIndex = 12;
            timesLeftLabel.Text = "?";
            timesLeftLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // quotient
            // 
            quotient.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            quotient.Location = new Point(289, 233);
            quotient.Name = "quotient";
            quotient.Size = new Size(100, 38);
            quotient.TabIndex = 4;
            quotient.Enter += anwser_Enter;
            // 
            // label11
            // 
            label11.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(234, 225);
            label11.Name = "label11";
            label11.Size = new Size(60, 50);
            label11.TabIndex = 20;
            label11.Text = "=";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dividedRightLabel
            // 
            dividedRightLabel.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            dividedRightLabel.Location = new Point(168, 225);
            dividedRightLabel.Name = "dividedRightLabel";
            dividedRightLabel.Size = new Size(60, 50);
            dividedRightLabel.TabIndex = 19;
            dividedRightLabel.Text = "?";
            dividedRightLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            label13.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label13.Location = new Point(116, 225);
            label13.Name = "label13";
            label13.Size = new Size(60, 50);
            label13.TabIndex = 18;
            label13.Text = "/";
            label13.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dividedLeftLabel
            // 
            dividedLeftLabel.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            dividedLeftLabel.Location = new Point(50, 225);
            dividedLeftLabel.Name = "dividedLeftLabel";
            dividedLeftLabel.Size = new Size(60, 50);
            dividedLeftLabel.TabIndex = 17;
            dividedLeftLabel.Text = "?";
            dividedLeftLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // startButton
            // 
            startButton.AutoSize = true;
            startButton.Font = new Font("Microsoft JhengHei UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            startButton.Location = new Point(179, 298);
            startButton.Name = "startButton";
            startButton.Size = new Size(100, 34);
            startButton.TabIndex = 0;
            startButton.Text = "StartTest";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 361);
            Controls.Add(startButton);
            Controls.Add(quotient);
            Controls.Add(label11);
            Controls.Add(dividedRightLabel);
            Controls.Add(label13);
            Controls.Add(dividedLeftLabel);
            Controls.Add(product);
            Controls.Add(label7);
            Controls.Add(timesRightLabel);
            Controls.Add(label9);
            Controls.Add(timesLeftLabel);
            Controls.Add(difference);
            Controls.Add(label2);
            Controls.Add(minusRightLabel);
            Controls.Add(label5);
            Controls.Add(minusLeftLabel);
            Controls.Add(sum);
            Controls.Add(label3);
            Controls.Add(plusRightLabel);
            Controls.Add(label1);
            Controls.Add(plusLeftLabel);
            Controls.Add(TimeLeft);
            Controls.Add(timeLabel);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "Form1";
            Text = "MathQuiz";
            ((System.ComponentModel.ISupportInitialize)sum).EndInit();
            ((System.ComponentModel.ISupportInitialize)difference).EndInit();
            ((System.ComponentModel.ISupportInitialize)product).EndInit();
            ((System.ComponentModel.ISupportInitialize)quotient).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label timeLabel;
        private Label TimeLeft;
        private Label plusLeftLabel;
        private Label label1;
        private Label plusRightLabel;
        private Label label3;
        private NumericUpDown sum;
        private NumericUpDown difference;
        private Label label2;
        private Label minusRightLabel;
        private Label label5;
        private Label minusLeftLabel;
        private NumericUpDown product;
        private Label label7;
        private Label timesRightLabel;
        private Label label9;
        private Label timesLeftLabel;
        private NumericUpDown quotient;
        private Label label11;
        private Label dividedRightLabel;
        private Label label13;
        private Label dividedLeftLabel;
        private Button startButton;
        private System.Windows.Forms.Timer timer1;
    }
}