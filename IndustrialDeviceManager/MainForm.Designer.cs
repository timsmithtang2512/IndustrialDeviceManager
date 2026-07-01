namespace IndustrialDeviceManager
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
            this.btnWriteLog = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbPort = new System.Windows.Forms.ComboBox();
            this.cmbBaud = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.txtReceive = new System.Windows.Forms.TextBox();
            this.btnSendHex = new System.Windows.Forms.Button();
            this.btnSendText = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTcpPort = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnTcpSend = new System.Windows.Forms.Button();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.btnStopServer = new System.Windows.Forms.Button();
            this.chkHexSend = new System.Windows.Forms.CheckBox();
            this.chkHexReceive = new System.Windows.Forms.CheckBox();
            this.dgvLog = new System.Windows.Forms.DataGridView();
            this.btnViewLog = new System.Windows.Forms.Button();
            this.groupSerial = new System.Windows.Forms.GroupBox();
            this.groupTcp = new System.Windows.Forms.GroupBox();
            this.groupLog = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            this.groupSerial.SuspendLayout();
            this.groupTcp.SuspendLayout();
            this.groupLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnWriteLog
            // 
            this.btnWriteLog.Location = new System.Drawing.Point(14, 28);
            this.btnWriteLog.Name = "btnWriteLog";
            this.btnWriteLog.Size = new System.Drawing.Size(88, 28);
            this.btnWriteLog.TabIndex = 0;
            this.btnWriteLog.Text = "写日志";
            this.btnWriteLog.UseVisualStyleBackColor = true;
            this.btnWriteLog.Click += new System.EventHandler(this.btnWriteLog_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(801, 548);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(86, 28);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // listBoxLog
            // 
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.ItemHeight = 12;
            this.listBoxLog.Location = new System.Drawing.Point(14, 62);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(259, 112);
            this.listBoxLog.TabIndex = 2;
            // 
            // lblStatus
            // 
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatus.Location = new System.Drawing.Point(12, 548);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(783, 28);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Ready";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbPort
            // 
            this.cmbPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPort.FormattingEnabled = true;
            this.cmbPort.Location = new System.Drawing.Point(64, 26);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(100, 20);
            this.cmbPort.TabIndex = 4;
            // 
            // cmbBaud
            // 
            this.cmbBaud.FormattingEnabled = true;
            this.cmbBaud.Location = new System.Drawing.Point(225, 26);
            this.cmbBaud.Name = "cmbBaud";
            this.cmbBaud.Size = new System.Drawing.Size(94, 20);
            this.cmbBaud.TabIndex = 5;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(337, 24);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(74, 24);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(417, 24);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(74, 24);
            this.btnOpen.TabIndex = 7;
            this.btnOpen.Text = "打开";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(497, 24);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 24);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(497, 58);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(74, 24);
            this.btnSend.TabIndex = 9;
            this.btnSend.Text = "串口发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(64, 60);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(255, 21);
            this.txtSend.TabIndex = 10;
            // 
            // txtReceive
            // 
            this.txtReceive.Location = new System.Drawing.Point(12, 244);
            this.txtReceive.Multiline = true;
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReceive.Size = new System.Drawing.Size(583, 288);
            this.txtReceive.TabIndex = 11;
            // 
            // btnSendHex
            // 
            this.btnSendHex.Location = new System.Drawing.Point(337, 58);
            this.btnSendHex.Name = "btnSendHex";
            this.btnSendHex.Size = new System.Drawing.Size(74, 24);
            this.btnSendHex.TabIndex = 12;
            this.btnSendHex.Text = "发HEX";
            this.btnSendHex.UseVisualStyleBackColor = true;
            this.btnSendHex.Click += new System.EventHandler(this.btnSendHex_Click);
            // 
            // btnSendText
            // 
            this.btnSendText.Location = new System.Drawing.Point(417, 58);
            this.btnSendText.Name = "btnSendText";
            this.btnSendText.Size = new System.Drawing.Size(74, 24);
            this.btnSendText.TabIndex = 13;
            this.btnSendText.Text = "发文本";
            this.btnSendText.UseVisualStyleBackColor = true;
            this.btnSendText.Click += new System.EventHandler(this.btnSendText_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(520, 214);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 24);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "清空接收";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "串口：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "IP：";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(64, 25);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(150, 21);
            this.txtIP.TabIndex = 17;
            this.txtIP.Text = "127.0.0.1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(232, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "端口：";
            // 
            // txtTcpPort
            // 
            this.txtTcpPort.Location = new System.Drawing.Point(279, 25);
            this.txtTcpPort.Name = "txtTcpPort";
            this.txtTcpPort.Size = new System.Drawing.Size(70, 21);
            this.txtTcpPort.TabIndex = 19;
            this.txtTcpPort.Text = "6000";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(366, 23);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(74, 24);
            this.btnConnect.TabIndex = 20;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(446, 23);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(74, 24);
            this.btnDisconnect.TabIndex = 21;
            this.btnDisconnect.Text = "断开";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnTcpSend
            // 
            this.btnTcpSend.Location = new System.Drawing.Point(526, 23);
            this.btnTcpSend.Name = "btnTcpSend";
            this.btnTcpSend.Size = new System.Drawing.Size(74, 24);
            this.btnTcpSend.TabIndex = 22;
            this.btnTcpSend.Text = "TCP发送";
            this.btnTcpSend.UseVisualStyleBackColor = true;
            this.btnTcpSend.Click += new System.EventHandler(this.btnTcpSend_Click);
            // 
            // btnStartServer
            // 
            this.btnStartServer.Location = new System.Drawing.Point(366, 58);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(114, 24);
            this.btnStartServer.TabIndex = 23;
            this.btnStartServer.Text = "启动TCP服务";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // btnStopServer
            // 
            this.btnStopServer.Location = new System.Drawing.Point(486, 58);
            this.btnStopServer.Name = "btnStopServer";
            this.btnStopServer.Size = new System.Drawing.Size(114, 24);
            this.btnStopServer.TabIndex = 24;
            this.btnStopServer.Text = "停止TCP服务";
            this.btnStopServer.UseVisualStyleBackColor = true;
            this.btnStopServer.Click += new System.EventHandler(this.btnStopServer_Click);
            // 
            // chkHexSend
            // 
            this.chkHexSend.AutoSize = true;
            this.chkHexSend.Location = new System.Drawing.Point(18, 62);
            this.chkHexSend.Name = "chkHexSend";
            this.chkHexSend.Size = new System.Drawing.Size(42, 16);
            this.chkHexSend.TabIndex = 25;
            this.chkHexSend.Text = "HEX";
            this.chkHexSend.UseVisualStyleBackColor = true;
            // 
            // chkHexReceive
            // 
            this.chkHexReceive.AutoSize = true;
            this.chkHexReceive.Checked = true;
            this.chkHexReceive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHexReceive.Location = new System.Drawing.Point(12, 220);
            this.chkHexReceive.Name = "chkHexReceive";
            this.chkHexReceive.Size = new System.Drawing.Size(72, 16);
            this.chkHexReceive.TabIndex = 26;
            this.chkHexReceive.Text = "HEX接收";
            this.chkHexReceive.UseVisualStyleBackColor = true;
            // 
            // dgvLog
            // 
            this.dgvLog.AllowUserToAddRows = false;
            this.dgvLog.AllowUserToDeleteRows = false;
            this.dgvLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLog.Location = new System.Drawing.Point(14, 180);
            this.dgvLog.Name = "dgvLog";
            this.dgvLog.ReadOnly = true;
            this.dgvLog.RowTemplate.Height = 23;
            this.dgvLog.Size = new System.Drawing.Size(259, 108);
            this.dgvLog.TabIndex = 27;
            // 
            // btnViewLog
            // 
            this.btnViewLog.Location = new System.Drawing.Point(108, 28);
            this.btnViewLog.Name = "btnViewLog";
            this.btnViewLog.Size = new System.Drawing.Size(88, 28);
            this.btnViewLog.TabIndex = 28;
            this.btnViewLog.Text = "查看日志";
            this.btnViewLog.UseVisualStyleBackColor = true;
            this.btnViewLog.Click += new System.EventHandler(this.btnViewLog_Click);
            // 
            // groupSerial
            // 
            this.groupSerial.Controls.Add(this.label1);
            this.groupSerial.Controls.Add(this.cmbPort);
            this.groupSerial.Controls.Add(this.cmbBaud);
            this.groupSerial.Controls.Add(this.btnRefresh);
            this.groupSerial.Controls.Add(this.btnOpen);
            this.groupSerial.Controls.Add(this.btnClose);
            this.groupSerial.Controls.Add(this.chkHexSend);
            this.groupSerial.Controls.Add(this.txtSend);
            this.groupSerial.Controls.Add(this.btnSendHex);
            this.groupSerial.Controls.Add(this.btnSendText);
            this.groupSerial.Controls.Add(this.btnSend);
            this.groupSerial.Location = new System.Drawing.Point(12, 12);
            this.groupSerial.Name = "groupSerial";
            this.groupSerial.Size = new System.Drawing.Size(583, 96);
            this.groupSerial.TabIndex = 29;
            this.groupSerial.TabStop = false;
            this.groupSerial.Text = "串口通信";
            // 
            // groupTcp
            // 
            this.groupTcp.Controls.Add(this.label2);
            this.groupTcp.Controls.Add(this.txtIP);
            this.groupTcp.Controls.Add(this.label3);
            this.groupTcp.Controls.Add(this.txtTcpPort);
            this.groupTcp.Controls.Add(this.btnConnect);
            this.groupTcp.Controls.Add(this.btnDisconnect);
            this.groupTcp.Controls.Add(this.btnTcpSend);
            this.groupTcp.Controls.Add(this.btnStartServer);
            this.groupTcp.Controls.Add(this.btnStopServer);
            this.groupTcp.Location = new System.Drawing.Point(12, 114);
            this.groupTcp.Name = "groupTcp";
            this.groupTcp.Size = new System.Drawing.Size(620, 94);
            this.groupTcp.TabIndex = 30;
            this.groupTcp.TabStop = false;
            this.groupTcp.Text = "TCP通信";
            // 
            // groupLog
            // 
            this.groupLog.Controls.Add(this.btnWriteLog);
            this.groupLog.Controls.Add(this.btnViewLog);
            this.groupLog.Controls.Add(this.listBoxLog);
            this.groupLog.Controls.Add(this.dgvLog);
            this.groupLog.Location = new System.Drawing.Point(601, 12);
            this.groupLog.Name = "groupLog";
            this.groupLog.Size = new System.Drawing.Size(286, 520);
            this.groupLog.TabIndex = 31;
            this.groupLog.TabStop = false;
            this.groupLog.Text = "日志";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 588);
            this.Controls.Add(this.groupLog);
            this.Controls.Add(this.groupTcp);
            this.Controls.Add(this.groupSerial);
            this.Controls.Add(this.chkHexReceive);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtReceive);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnExit);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Industrial Device Manager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            this.groupSerial.ResumeLayout(false);
            this.groupSerial.PerformLayout();
            this.groupTcp.ResumeLayout(false);
            this.groupTcp.PerformLayout();
            this.groupLog.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWriteLog;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbPort;
        private System.Windows.Forms.ComboBox cmbBaud;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.TextBox txtReceive;
        private System.Windows.Forms.Button btnSendHex;
        private System.Windows.Forms.Button btnSendText;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTcpPort;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnTcpSend;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.Button btnStopServer;
        private System.Windows.Forms.CheckBox chkHexSend;
        private System.Windows.Forms.CheckBox chkHexReceive;
        private System.Windows.Forms.DataGridView dgvLog;
        private System.Windows.Forms.Button btnViewLog;
        private System.Windows.Forms.GroupBox groupSerial;
        private System.Windows.Forms.GroupBox groupTcp;
        private System.Windows.Forms.GroupBox groupLog;
    }
}
