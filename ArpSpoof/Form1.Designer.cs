namespace ArpSpoof
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.adapterComboBox = new System.Windows.Forms.ComboBox();
            this.adapterLabel = new System.Windows.Forms.Label();
            this.scanButton = new System.Windows.Forms.Button();
            this.targetComboBox = new System.Windows.Forms.ComboBox();
            this.targetLabel = new System.Windows.Forms.Label();
            this.gatewayIpLabel = new System.Windows.Forms.Label();
            this.gatewayIpTextBox = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.logTextBox = new System.Windows.Forms.RichTextBox();
            this.stopScanButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // adapterComboBox
            // 
            this.adapterComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.adapterComboBox.ForeColor = System.Drawing.Color.White;
            this.adapterComboBox.Location = new System.Drawing.Point(153, 28);
            this.adapterComboBox.Name = "adapterComboBox";
            this.adapterComboBox.Size = new System.Drawing.Size(737, 21);
            this.adapterComboBox.TabIndex = 1;
            // 
            // adapterLabel
            // 
            this.adapterLabel.AutoSize = true;
            this.adapterLabel.ForeColor = System.Drawing.Color.White;
            this.adapterLabel.Location = new System.Drawing.Point(20, 36);
            this.adapterLabel.Name = "adapterLabel";
            this.adapterLabel.Size = new System.Drawing.Size(80, 13);
            this.adapterLabel.TabIndex = 0;
            this.adapterLabel.Text = "Select Adapter:";
            // 
            // scanButton
            // 
            this.scanButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.scanButton.ForeColor = System.Drawing.Color.White;
            this.scanButton.Location = new System.Drawing.Point(153, 55);
            this.scanButton.Name = "scanButton";
            this.scanButton.Size = new System.Drawing.Size(60, 20);
            this.scanButton.TabIndex = 2;
            this.scanButton.Text = "Scan";
            this.scanButton.UseVisualStyleBackColor = false;
            this.scanButton.Click += new System.EventHandler(this.scanButton_Click);
            // 
            // targetComboBox
            // 
            this.targetComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.targetComboBox.ForeColor = System.Drawing.Color.White;
            this.targetComboBox.Location = new System.Drawing.Point(153, 89);
            this.targetComboBox.Name = "targetComboBox";
            this.targetComboBox.Size = new System.Drawing.Size(737, 21);
            this.targetComboBox.TabIndex = 4;
            // 
            // targetLabel
            // 
            this.targetLabel.AutoSize = true;
            this.targetLabel.ForeColor = System.Drawing.Color.White;
            this.targetLabel.Location = new System.Drawing.Point(23, 92);
            this.targetLabel.Name = "targetLabel";
            this.targetLabel.Size = new System.Drawing.Size(111, 13);
            this.targetLabel.TabIndex = 3;
            this.targetLabel.Text = "Select Target Device:";
            // 
            // gatewayIpLabel
            // 
            this.gatewayIpLabel.AutoSize = true;
            this.gatewayIpLabel.ForeColor = System.Drawing.Color.White;
            this.gatewayIpLabel.Location = new System.Drawing.Point(23, 132);
            this.gatewayIpLabel.Name = "gatewayIpLabel";
            this.gatewayIpLabel.Size = new System.Drawing.Size(106, 13);
            this.gatewayIpLabel.TabIndex = 5;
            this.gatewayIpLabel.Text = "Gateway IP Address:";
            // 
            // gatewayIpTextBox
            // 
            this.gatewayIpTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.gatewayIpTextBox.ForeColor = System.Drawing.Color.White;
            this.gatewayIpTextBox.Location = new System.Drawing.Point(153, 129);
            this.gatewayIpTextBox.Name = "gatewayIpTextBox";
            this.gatewayIpTextBox.Size = new System.Drawing.Size(737, 20);
            this.gatewayIpTextBox.TabIndex = 6;
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.startButton.ForeColor = System.Drawing.Color.White;
            this.startButton.Location = new System.Drawing.Point(23, 206);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(150, 30);
            this.startButton.TabIndex = 7;
            this.startButton.Text = "Start Spoofing";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.stopButton.ForeColor = System.Drawing.Color.White;
            this.stopButton.Location = new System.Drawing.Point(740, 206);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(150, 30);
            this.stopButton.TabIndex = 8;
            this.stopButton.Text = "Stop Spoofing";
            this.stopButton.UseVisualStyleBackColor = false;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // logTextBox
            // 
            this.logTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.logTextBox.ForeColor = System.Drawing.Color.White;
            this.logTextBox.Location = new System.Drawing.Point(23, 242);
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.Size = new System.Drawing.Size(867, 200);
            this.logTextBox.TabIndex = 9;
            this.logTextBox.Text = "";
            // 
            // stopScanButton
            // 
            this.stopScanButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.stopScanButton.ForeColor = System.Drawing.Color.White;
            this.stopScanButton.Location = new System.Drawing.Point(219, 55);
            this.stopScanButton.Name = "stopScanButton";
            this.stopScanButton.Size = new System.Drawing.Size(60, 20);
            this.stopScanButton.TabIndex = 3;
            this.stopScanButton.Text = "Stop Scan";
            this.stopScanButton.UseVisualStyleBackColor = false;
            this.stopScanButton.Click += new System.EventHandler(this.stopScanButton_Click);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(946, 457);
            this.Controls.Add(this.stopScanButton);
            this.Controls.Add(this.adapterLabel);
            this.Controls.Add(this.adapterComboBox);
            this.Controls.Add(this.scanButton);
            this.Controls.Add(this.targetLabel);
            this.Controls.Add(this.targetComboBox);
            this.Controls.Add(this.gatewayIpLabel);
            this.Controls.Add(this.gatewayIpTextBox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.logTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Opacity = 0.9D;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ARP Spoofing Tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ComboBox adapterComboBox;
        private System.Windows.Forms.Label adapterLabel;
        private System.Windows.Forms.Button scanButton;
        private System.Windows.Forms.Button stopScanButton;
        private System.Windows.Forms.ComboBox targetComboBox;
        private System.Windows.Forms.Label targetLabel;
        private System.Windows.Forms.Label gatewayIpLabel;
        private System.Windows.Forms.TextBox gatewayIpTextBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.RichTextBox logTextBox;


        #endregion
    }
}
