﻿namespace WinformTCPClient
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
            ConnectButton = new Button();
            textBox1 = new TextBox();
            ConnectShow = new Label();
            DecodeButton = new Button();
            AnalysisButton = new Button();
            SuspendLayout();
            // 
            // ConnectButton
            // 
            ConnectButton.Location = new Point(44, 69);
            ConnectButton.Name = "ConnectButton";
            ConnectButton.Size = new Size(150, 46);
            ConnectButton.TabIndex = 0;
            ConnectButton.Text = "Connect";
            ConnectButton.UseVisualStyleBackColor = true;
            ConnectButton.Click += ConnectButton_Click;
            // 
            // textBox1
            // 
            textBox1.AcceptsReturn = true;
            textBox1.Location = new Point(349, 69);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(1228, 1061);
            textBox1.TabIndex = 1;
            // 
            // ConnectShow
            // 
            ConnectShow.AutoSize = true;
            ConnectShow.Location = new Point(44, 500);
            ConnectShow.Name = "ConnectShow";
            ConnectShow.Size = new Size(0, 30);
            ConnectShow.TabIndex = 3;
            // 
            // DecodeButton
            // 
            DecodeButton.Location = new Point(44, 143);
            DecodeButton.Name = "DecodeButton";
            DecodeButton.Size = new Size(150, 46);
            DecodeButton.TabIndex = 4;
            DecodeButton.Text = "Decode";
            DecodeButton.UseVisualStyleBackColor = true;
            DecodeButton.Click += DecodeButton_Click;
            // 
            // AnalysisButton
            // 
            AnalysisButton.Location = new Point(44, 221);
            AnalysisButton.Name = "AnalysisButton";
            AnalysisButton.Size = new Size(150, 46);
            AnalysisButton.TabIndex = 5;
            AnalysisButton.Text = "Analysis";
            AnalysisButton.UseVisualStyleBackColor = true;
            AnalysisButton.Click += AnalysisButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(14F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1574, 1129);
            Controls.Add(AnalysisButton);
            Controls.Add(DecodeButton);
            Controls.Add(ConnectShow);
            Controls.Add(textBox1);
            Controls.Add(ConnectButton);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ConnectButton;
        private TextBox textBox1;
        private Label ConnectShow;
        private Button DecodeButton;
        private Button AnalysisButton;
    }
}