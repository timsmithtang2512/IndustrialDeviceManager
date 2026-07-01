using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using IndustrialDeviceManager.Common;
using IndustrialDeviceManager.Communication;
using IndustrialDeviceManager.DAL;

namespace IndustrialDeviceManager
{
    public partial class MainForm : Form
    {
        private SerialManager serial;
        private TcpClientManager tcp;
        private TcpServerManager server;
        private BackgroundWorker worker;

        private Queue<byte[]> receiveQueue =
            new Queue<byte[]>();

        private object locker =
            new object();

        public MainForm()
        {
            InitializeComponent();

            serial = new SerialManager();
            serial.DataReceived += serial_DataReceived;

            tcp = new TcpClientManager();
            tcp.DataReceived += tcp_DataReceived;

            server = new TcpServerManager();
            server.ClientConnected += server_ClientConnected;
            server.ClientDisconnected += server_ClientDisconnected;
            server.DataReceived += server_DataReceived;

            worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerAsync();
        }

        private void MainForm_Load(
            object sender,
            EventArgs e)
        {
            Logger.Info("程序启动");

            lblStatus.Text = "系统启动成功";

            AddLog("欢迎使用 Industrial Device Manager");

            if (!SQLiteHelper.TestConnection())
            {
                MessageBox.Show("数据库连接失败");
                Logger.Error("数据库连接失败");
            }

            InitBaudList();
            RefreshPorts();
            LoadLogs();
        }

        private void InitBaudList()
        {
            cmbBaud.Items.Clear();
            cmbBaud.Items.Add("9600");
            cmbBaud.Items.Add("19200");
            cmbBaud.Items.Add("38400");
            cmbBaud.Items.Add("57600");
            cmbBaud.Items.Add("115200");
            cmbBaud.SelectedItem = "115200";
        }

        private void AddLog(string msg)
        {
            listBoxLog.Items.Insert(
                0,
                DateTime.Now.ToString("HH:mm:ss") + "    " + msg);
        }

        private void btnWriteLog_Click(
            object sender,
            EventArgs e)
        {
            Logger.Info("点击了写日志按钮");

            AddLog("日志写入成功");
            LoadLogs();
        }

        private void btnExit_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }

        private void serial_DataReceived(byte[] data)
        {
            lock (locker)
            {
                receiveQueue.Enqueue(data);
            }
        }

        private void worker_DoWork(
            object sender,
            DoWorkEventArgs e)
        {
            while (!worker.CancellationPending)
            {
                byte[] data = null;

                lock (locker)
                {
                    if (receiveQueue.Count > 0)
                    {
                        data = receiveQueue.Dequeue();
                    }
                }

                if (data != null)
                {
                    ShowReceive(data);
                }

                System.Threading.Thread.Sleep(10);
            }
        }

        private void btnOpen_Click(
            object sender,
            EventArgs e)
        {
            if (cmbPort.Text.Trim().Length == 0)
            {
                MessageBox.Show("请选择串口");
                return;
            }

            int baud;
            if (!int.TryParse(cmbBaud.Text, out baud))
            {
                MessageBox.Show("波特率不正确");
                return;
            }

            if (serial.Open(cmbPort.Text, baud))
            {
                Logger.Info("打开串口：" + cmbPort.Text);
                lblStatus.Text = "串口已连接";
                AddLog("串口已连接：" + cmbPort.Text);
            }
            else
            {
                MessageBox.Show("打开串口失败");
            }
        }

        private void btnClose_Click(
            object sender,
            EventArgs e)
        {
            serial.Close();
            Logger.Info("关闭串口");

            lblStatus.Text = "串口未连接";
            AddLog("串口已关闭");
        }

        private void btnSend_Click(
            object sender,
            EventArgs e)
        {
            SendSerialByMode();
        }

        private void btnSendHex_Click(
            object sender,
            EventArgs e)
        {
            SendSerialHex();
        }

        private void btnSendText_Click(
            object sender,
            EventArgs e)
        {
            serial.Send(txtSend.Text);
            Logger.Info("ASCII发送：" + txtSend.Text);
        }

        private void SendSerialByMode()
        {
            if (chkHexSend.Checked)
            {
                SendSerialHex();
            }
            else
            {
                serial.Send(txtSend.Text);
                Logger.Info("ASCII发送：" + txtSend.Text);
            }
        }

        private void SendSerialHex()
        {
            byte[] data;

            if (!TryGetHexBytes(txtSend.Text, out data))
            {
                MessageBox.Show("HEX格式不正确，请输入偶数位十六进制字符");
                return;
            }

            serial.Send(data);

            Logger.Info("HEX发送：" + txtSend.Text);
        }

        private void ShowReceive(byte[] data)
        {
            if (InvokeRequired)
            {
                BeginInvoke(
                    new Action<byte[]>(ShowReceive),
                    data);

                return;
            }

            string text;

            if (chkHexReceive.Checked)
            {
                text = HexHelper.ByteToHex(data);
            }
            else
            {
                text = System.Text.Encoding.ASCII.GetString(data);
            }

            txtReceive.AppendText(
                DateTime.Now.ToString("HH:mm:ss.fff ") +
                text +
                Environment.NewLine);

            txtReceive.SelectionStart = txtReceive.Text.Length;
            txtReceive.ScrollToCaret();

            Logger.Info("串口收到数据");
        }

        private void btnClear_Click(
            object sender,
            EventArgs e)
        {
            txtReceive.Clear();
            Logger.Info("清空接收窗口");
        }

        private void btnRefresh_Click(
            object sender,
            EventArgs e)
        {
            RefreshPorts();
        }

        private void RefreshPorts()
        {
            cmbPort.Items.Clear();

            string[] ports = SerialManager.GetPortNames();

            cmbPort.Items.AddRange(ports);

            if (ports.Length > 0)
            {
                cmbPort.SelectedIndex = 0;
            }

            Logger.Info("刷新串口列表");
        }

        private void btnViewLog_Click(
            object sender,
            EventArgs e)
        {
            LoadLogs();
        }

        private void LoadLogs()
        {
            LogRepository repo = new LogRepository();
            dgvLog.DataSource = repo.GetAll();
        }

        private void tcp_DataReceived(byte[] data)
        {
            if (InvokeRequired)
            {
                BeginInvoke(
                    new Action<byte[]>(tcp_DataReceived),
                    data);

                return;
            }

            txtReceive.AppendText(
                DateTime.Now.ToString("HH:mm:ss.fff ") +
                "[TCP] " +
                HexHelper.ByteToHex(data) +
                Environment.NewLine);
        }

        private void btnConnect_Click(
            object sender,
            EventArgs e)
        {
            int port;
            if (!TryGetTcpPort(out port))
            {
                return;
            }

            bool ok = tcp.Open(txtIP.Text.Trim(), port);

            if (ok)
            {
                Logger.Info("TCP连接成功");
                lblStatus.Text = "TCP Connected";
                AddLog("TCP连接成功");
            }
            else
            {
                MessageBox.Show("连接失败");
            }
        }

        private void btnDisconnect_Click(
            object sender,
            EventArgs e)
        {
            tcp.Close();

            lblStatus.Text = "Disconnected";
            AddLog("TCP已断开");
        }

        private void btnTcpSend_Click(
            object sender,
            EventArgs e)
        {
            if (chkHexSend.Checked)
            {
                byte[] data;

                if (!TryGetHexBytes(txtSend.Text, out data))
                {
                    MessageBox.Show("HEX格式不正确，请输入偶数位十六进制字符");
                    return;
                }

                tcp.Send(data);
            }
            else
            {
                tcp.Send(txtSend.Text);
            }
        }

        private void server_ClientConnected(
            TcpClient client)
        {
            if (InvokeRequired)
            {
                BeginInvoke(
                    new Action<TcpClient>(server_ClientConnected),
                    client);

                return;
            }

            Logger.Info("客户端连接");

            txtReceive.AppendText("Client Connected" + Environment.NewLine);
        }

        private void server_ClientDisconnected(
            TcpClient client)
        {
            if (InvokeRequired)
            {
                BeginInvoke(
                    new Action<TcpClient>(server_ClientDisconnected),
                    client);

                return;
            }

            Logger.Info("客户端断开");

            txtReceive.AppendText("Client Disconnected" + Environment.NewLine);
        }

        private void server_DataReceived(
            TcpClient client,
            byte[] data)
        {
            if (InvokeRequired)
            {
                BeginInvoke(
                    new Action<TcpClient, byte[]>(server_DataReceived),
                    client,
                    data);

                return;
            }

            txtReceive.AppendText(
                DateTime.Now.ToString("HH:mm:ss.fff ") +
                "[Server] " +
                HexHelper.ByteToHex(data) +
                Environment.NewLine);
        }

        private void btnStartServer_Click(
            object sender,
            EventArgs e)
        {
            int port;
            if (!TryGetTcpPort(out port))
            {
                return;
            }

            if (server.Start(port))
            {
                lblStatus.Text = "Server Running";
                Logger.Info("TCP服务器启动");
                AddLog("TCP服务器启动：" + port.ToString());
            }
            else
            {
                MessageBox.Show("TCP服务器启动失败");
            }
        }

        private void btnStopServer_Click(
            object sender,
            EventArgs e)
        {
            server.Stop();

            lblStatus.Text = "Stopped";
            Logger.Info("TCP服务器停止");
            AddLog("TCP服务器停止");
        }

        private bool TryGetTcpPort(out int port)
        {
            port = 0;

            if (!int.TryParse(txtTcpPort.Text, out port) ||
                port <= 0 ||
                port > 65535)
            {
                MessageBox.Show("端口号必须是1到65535之间的数字");
                return false;
            }

            return true;
        }

        private bool TryGetHexBytes(
            string text,
            out byte[] data)
        {
            data = null;

            string hex = text.Replace(" ", "");

            if (hex.Length == 0 ||
                hex.Length % 2 != 0 ||
                !Regex.IsMatch(hex, "^[0-9a-fA-F]+$"))
            {
                return false;
            }

            data = HexHelper.HexToByte(hex);
            return true;
        }

        protected override void OnFormClosing(
            FormClosingEventArgs e)
        {
            if (worker != null)
            {
                worker.CancelAsync();
            }

            if (serial != null)
            {
                serial.Close();
            }

            if (tcp != null)
            {
                tcp.Close();
            }

            if (server != null)
            {
                server.Stop();
            }

            Logger.Info("程序退出");

            base.OnFormClosing(e);
        }
    }
}
