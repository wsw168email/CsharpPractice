namespace WinformTCPListener
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
            textBox1 = new TextBox();
            ConnectButton = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.AcceptsReturn = true;
            textBox1.Location = new Point(411, 68);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(1151, 1049);
            textBox1.TabIndex = 2;
            // 
            // ConnectButton
            // 
            ConnectButton.Location = new Point(54, 107);
            ConnectButton.Name = "ConnectButton";
            ConnectButton.Size = new Size(150, 46);
            ConnectButton.TabIndex = 4;
            ConnectButton.Text = "Connect";
            ConnectButton.UseVisualStyleBackColor = true;
            ConnectButton.Click += ConnectButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(14F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1574, 1129);
            Controls.Add(ConnectButton);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button ConnectButton;
        public static TextBox textBox1;
    }
}