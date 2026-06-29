/*
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IndustrialDeviceManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
 */
using System;
using System.Windows.Forms;
using IndustrialDeviceManager.Common;
using IndustrialDeviceManager.DAL;
using IndustrialDeviceManager.Models;
using IndustrialDeviceManager.Communication;
using System.ComponentModel;
using System.Collections.Generic;


namespace IndustrialDeviceManager
{
    public partial class MainForm : Form
    {
        tcp =
            new TcpClientManager();

        tcp.DataReceived +=
        tcp_DataReceived;private TcpClientManager tcp;

        private TcpServerManager server;
        server =
            new TcpServerManager();

        server.ClientConnected +=
            server_ClientConnected;

        server.ClientDisconnected +=
            server_ClientDisconnected;

        server.DataReceived +=
            server_DataReceived;



        private SerialManager serial;
        private BackgroundWorker worker;

        private Queue<byte[]> receiveQueue =
            new Queue<byte[]>();

        private object locker =
            new object();

        public MainForm()
        {
            InitializeComponent();

            serial =
            new SerialManager();

            worker =
            new BackgroundWorker();

            worker.WorkerSupportsCancellation = true;

            worker.DoWork += worker_DoWork;

            worker.RunWorkerAsync();

            serial.DataReceived +=
            serial_DataReceived;

        }

        private void MainForm_Load(
            object sender,
            EventArgs e)
        {
            Logger.Info("程序启动");

            lblStatus.Text = "系统启动成功";

            AddLog("欢迎使用 Industrial Device Manager");

            if (SQLiteHelper.TestConnection())
            {
                MessageBox.Show("数据库连接成功");
            }
            else
            {
                MessageBox.Show("数据库连接失败");
            }
            DeviceRepository repo =
            new DeviceRepository();

            DeviceInfo device =
                new DeviceInfo();

            device.DeviceName = "扫码枪";

            device.DeviceType = "USB";

            device.SerialNumber = "SN0001";

            device.Status = "Online";

            device.CreateTime =
                DateTime.Now.ToString();

            repo.Add(device);



            cmbPort.Items.Clear();

            cmbPort.Items.AddRange(
                SerialManager.GetPortNames());

            if (cmbPort.Items.Count > 0)
            {
                cmbPort.SelectedIndex = 0;
            }

            btnRefresh_Click(null, null);

        }

        private void btnWriteLog_Click(
            object sender,
            EventArgs e)
        {
            Logger.Info("点击了写日志按钮");

            AddLog("日志写入成功");
        }

        private void AddLog(string msg)
        {
            listBoxLog.Items.Insert(
                0,
                DateTime.Now.ToString("HH:mm:ss")
                + "    "
                + msg);
        }

        private void btnExit_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }

        void serial_DataReceived(byte[] data)
        {

            lock (locker)
            {
                receiveQueue.Enqueue(data);
            }

            ShowReceive(data);
            /*
            string hex = "";

            foreach (byte b in data)
            {
                hex +=
                    b.ToString("X2") + " ";
            }

            MessageBox.Show(hex);
             */
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            
            /*
            bool ok =
                    serial.Open(
                    cmbPort.Text,
                    115200);

            if (ok)
            {
                MessageBox.Show("打开成功");
            }
            else
            {
                MessageBox.Show("打开失败");
            }
             */

            int baud =
        Convert.ToInt32(cmbBaud.Text);

            if (serial.Open(cmbPort.Text, baud))
            {
                Logger.Info("打开串口：" + cmbPort.Text);

                lblStatus.Text = "已连接";
            }
            else
            {
                MessageBox.Show("打开失败");
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            serial.Close();
            Logger.Info("关闭串口");

            lblStatus.Text = "未连接";

        }

        private void btnSend_Click(object sender, EventArgs e)
        {

            //serial.Send(txtSend.Text);
            if (chkHexSend.Checked)
            {
                byte[] data =
                    HexHelper.HexToByte(
                    txtSend.Text);

                serial.Send(data);

                Logger.Info(
                    "HEX发送：" +
                    txtSend.Text);
            }
            else
            {
                serial.Send(txtSend.Text);

                Logger.Info(
                    "ASCII发送：" +
                    txtSend.Text);
            }

        }


        void worker_DoWork(
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
                        data =
                            receiveQueue.Dequeue();
                    }
                }

                if (data != null)
                {
                    ShowReceive(data);
                }

                System.Threading.Thread.Sleep(10);
            }
        }



        private void ShowReceive(byte[] data)
        {
            if (InvokeRequired)
            {
                BeginInvoke(
                    new Action<byte[]>(
                        ShowReceive),
                    data);

                return;
            }
            string text;

            if (chkHexReceive.Checked)
            {
                text =
                    HexHelper.ByteToHex(data);
            }
            else
            {
                text =
                    System.Text.Encoding.ASCII
                    .GetString(data);
            }

            txtReceive.AppendText(

                DateTime.Now.ToString(
                "HH:mm:ss.fff ")

                + text

                + Environment.NewLine);

            txtReceive.SelectionStart =
                txtReceive.Text.Length;

            txtReceive.ScrollToCaret();



            /*
            string hex =
        HexHelper.ByteToHex(data);


            txtReceive.AppendText(

        DateTime.Now.ToString(
        "HH:mm:ss ")

        + hex

        + Environment.NewLine);

            Logger.Info(
                "Receive " + hex);
             */
            Logger.Info(
            "串口收到数据");
             
        }


        protected override void OnFormClosing(
    FormClosingEventArgs e)
        {
            serial.Close();

            Logger.Info("程序退出");

            base.OnFormClosing(e);
            /*

            if (worker != null)
            {
                worker.CancelAsync();
            }

            base.OnFormClosing(e);
             */
        }

        private void btnSendHex_Click(object sender, EventArgs e)
        {
            byte[] data =
                        HexHelper.HexToByte(
                        txtSend.Text);

            serial.Send(data);

            Logger.Info(
                "Send " +
                txtSend.Text);

        }

        private void btnSendText_Click(object sender, EventArgs e)
        {
            serial.Send(
                            txtSend.Text);

            Logger.Info(
                txtSend.Text);

        }

        //增加自动滚动
        /*
        txtReceive.SelectionStart =
        txtReceive.Text.Length;

        txtReceive.ScrollToCaret();
         */
         

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtReceive.Clear();
            Logger.Info("清空接收窗口");
        }


        private void btnRefresh_Click(object sender, EventArgs e)
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
            LogRepository repo =
                new LogRepository();

            dgvLog.DataSource =
                repo.GetAll();
        }

        void tcp_DataReceived(byte[] data)
        {
            if (InvokeRequired)
            {
                BeginInvoke(
                new Action<byte[]>(
                tcp_DataReceived),
                data);

                return;
             }

            txtReceive.AppendText(

             "[TCP] "

            + HexHelper.ByteToHex(data)

            + Environment.NewLine);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {   
            bool ok =
            tcp.Open(
            txtIP.Text,
            Convert.ToInt32(
            txtTcpPort.Text));

            if (ok)
            {
                Logger.Info(
                "TCP连接成功");

                lblStatus.Text =
                "TCP Connected";
            }
            else
            {
                MessageBox.Show(
                "连接失败");
            }
        
          }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            tcp.Close();

            lblStatus.Text =
            "Disconnected";

        }

        private void btnTcpSend_Click(object sender, EventArgs e)
        {
            
            if (chkHexSend.Checked)
            {
                tcp.Send(
                HexHelper.HexToByte(
                txtSend.Text));
            }
            else
            {
                tcp.Send(
                txtSend.Text);
            }
        }

        void server_ClientConnected(
                    TcpClient client)
        {
            if (InvokeRequired)
            {
                BeginInvoke(
                new Action<TcpClient>(
                server_ClientConnected),
                client);

                return;
            }

            Logger.Info("客户端连接");

            txtReceive.AppendText(
            "Client Connected\r\n");
        }

        void server_ClientDisconnected(
                 TcpClient client)
        {
            if (InvokeRequired)
            {
                BeginInvoke(
                new Action<TcpClient>(
                server_ClientDisconnected),
                client);

                return;
             }

            Logger.Info("客户端断开");

            txtReceive.AppendText(
            "Client Disconnected\r\n");
        }

        void server_DataReceived(
            TcpClient client,
            byte[] data)
        {
            if (InvokeRequired)
            {
                BeginInvoke(
                new Action<TcpClient, byte[]>(
                server_DataReceived),
                client,
                data);

                return;
                }

            txtReceive.AppendText(

            "[Server] "

            + HexHelper.ByteToHex(data)

            + Environment.NewLine);
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
             int port =
                Convert.ToInt32(
                txtTcpPort.Text);

            if (server.Start(port))
            {
                lblStatus.Text =
                "Server Running";

                Logger.Info(
                "TCP服务器启动");
            }
        
        }

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            server.Stop();

            lblStatus.Text =
            "Stopped";

            Logger.Info(
            "TCP服务器停止");
        }







    }
}
