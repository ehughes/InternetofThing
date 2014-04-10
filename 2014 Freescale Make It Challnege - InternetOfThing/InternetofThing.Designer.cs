namespace InternetOfThing
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.COM_PortComboBox = new System.Windows.Forms.ComboBox();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.TCP_ConnectButton = new System.Windows.Forms.Button();
            this.IP_TB = new System.Windows.Forms.TextBox();
            this.TCP_PORT_TB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ThingBox = new System.Windows.Forms.PictureBox();
            this.DebugTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ThingBox)).BeginInit();
            this.SuspendLayout();
            // 
            // COM_PortComboBox
            // 
            this.COM_PortComboBox.FormattingEnabled = true;
            this.COM_PortComboBox.Location = new System.Drawing.Point(981, 9);
            this.COM_PortComboBox.Name = "COM_PortComboBox";
            this.COM_PortComboBox.Size = new System.Drawing.Size(121, 21);
            this.COM_PortComboBox.TabIndex = 0;
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(979, 47);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(121, 23);
            this.ConnectButton.TabIndex = 1;
            this.ConnectButton.Text = "button1";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // TCP_ConnectButton
            // 
            this.TCP_ConnectButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.TCP_ConnectButton.FlatAppearance.BorderSize = 5;
            this.TCP_ConnectButton.Font = new System.Drawing.Font("Chiller", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TCP_ConnectButton.Location = new System.Drawing.Point(323, 72);
            this.TCP_ConnectButton.Name = "TCP_ConnectButton";
            this.TCP_ConnectButton.Size = new System.Drawing.Size(207, 39);
            this.TCP_ConnectButton.TabIndex = 5;
            this.TCP_ConnectButton.Text = "TCP Connect";
            this.TCP_ConnectButton.UseVisualStyleBackColor = true;
            this.TCP_ConnectButton.Click += new System.EventHandler(this.TCP_ConnectButton_Click);
            // 
            // IP_TB
            // 
            this.IP_TB.Font = new System.Drawing.Font("Chiller", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IP_TB.Location = new System.Drawing.Point(12, 72);
            this.IP_TB.Name = "IP_TB";
            this.IP_TB.Size = new System.Drawing.Size(134, 39);
            this.IP_TB.TabIndex = 6;
            this.IP_TB.Text = "1.2.3.4";
            this.IP_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TCP_PORT_TB
            // 
            this.TCP_PORT_TB.Font = new System.Drawing.Font("Chiller", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TCP_PORT_TB.Location = new System.Drawing.Point(176, 72);
            this.TCP_PORT_TB.Name = "TCP_PORT_TB";
            this.TCP_PORT_TB.Size = new System.Drawing.Size(121, 39);
            this.TCP_PORT_TB.TabIndex = 7;
            this.TCP_PORT_TB.Text = "2000";
            this.TCP_PORT_TB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Chiller", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(204, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 38);
            this.label1.TabIndex = 8;
            this.label1.Text = "Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Chiller", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 38);
            this.label2.TabIndex = 9;
            this.label2.Text = "IP Address";
            // 
            // ThingBox
            // 
            this.ThingBox.BackColor = System.Drawing.Color.Black;
            this.ThingBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ThingBox.Location = new System.Drawing.Point(12, 131);
            this.ThingBox.Name = "ThingBox";
            this.ThingBox.Size = new System.Drawing.Size(1088, 676);
            this.ThingBox.TabIndex = 10;
            this.ThingBox.TabStop = false;
            this.ThingBox.Click += new System.EventHandler(this.ThingBox_Click);
            this.ThingBox.Paint += new System.Windows.Forms.PaintEventHandler(this.ThingBox_Paint);
            this.ThingBox.MouseLeave += new System.EventHandler(this.ThingBox_MouseLeave);
            this.ThingBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ThingBox_MouseMove);
            this.ThingBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ThingBox_MouseUp);
            // 
            // DebugTB
            // 
            this.DebugTB.Font = new System.Drawing.Font("Chiller", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DebugTB.Location = new System.Drawing.Point(560, 73);
            this.DebugTB.Name = "DebugTB";
            this.DebugTB.Size = new System.Drawing.Size(333, 39);
            this.DebugTB.TabIndex = 11;
            this.DebugTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(814, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Serial Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Chiller", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(659, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 38);
            this.label4.TabIndex = 13;
            this.label4.Text = "Thing Command";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1114, 456);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DebugTB);
            this.Controls.Add(this.ThingBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TCP_PORT_TB);
            this.Controls.Add(this.IP_TB);
            this.Controls.Add(this.TCP_ConnectButton);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.COM_PortComboBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Internet of Thing Control Surface";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.ThingBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox COM_PortComboBox;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button TCP_ConnectButton;
        private System.Windows.Forms.TextBox IP_TB;
        private System.Windows.Forms.TextBox TCP_PORT_TB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox ThingBox;
        private System.Windows.Forms.TextBox DebugTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

