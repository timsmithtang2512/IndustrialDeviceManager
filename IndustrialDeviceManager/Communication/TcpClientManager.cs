/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndustrialDeviceManager.Communication
{
    class TcpClientManager
    {
    }
}
 */
using System;
using System.Net.Sockets;
using System.Threading;

namespace IndustrialDeviceManager.Communication
{
    /// <summary>
    /// TCP客户端
    /// </summary>
    public class TcpClientManager
    {
        private TcpClient client;

        private NetworkStream stream;

        private Thread receiveThread;

        public event Action<byte[]> DataReceived;

        public event Action Connected;

        public event Action Disconnected;

        public bool IsConnected
        {
            get
            {
                if (client == null)
                    return false;

                return client.Connected;
            }
        }

        /// <summary>
        /// 建立连接
        /// </summary>
        public bool Open(
            string ip,
            int port)
        {
            try
            {
                client = new TcpClient();

                client.Connect(ip, port);

                stream =
                    client.GetStream();

                receiveThread =
                    new Thread(ReceiveThread);

                receiveThread.IsBackground = true;

                receiveThread.Start();

                if (Connected != null)
                    Connected();

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        public void Close()
        {
            try
            {
                if (stream != null)
                {
                    stream.Close();
                }

                if (client != null)
                {
                    client.Close();
                }

                if (Disconnected != null)
                    Disconnected();
            }
            catch
            {
            }
        }

        /// <summary>
        /// 发送字符串
        /// </summary>
        public void Send(string text)
        {
            if (!IsConnected)
                return;

            byte[] buffer =
                System.Text.Encoding.ASCII.GetBytes(text);

            stream.Write(
                buffer,
                0,
                buffer.Length);
        }

        /// <summary>
        /// 发送字节
        /// </summary>
        public void Send(byte[] data)
        {
            if (!IsConnected)
                return;

            stream.Write(
                data,
                0,
                data.Length);
        }

        /// <summary>
        /// 接收线程
        /// </summary>
        private void ReceiveThread()
        {
            byte[] buffer =
                new byte[4096];

            while (client != null &&
                   client.Connected)
            {
                try
                {
                    int len =
                        stream.Read(
                        buffer,
                        0,
                        buffer.Length);

                    if (len <= 0)
                        break;

                    byte[] data =
                        new byte[len];

                    Array.Copy(
                        buffer,
                        data,
                        len);

                    if (DataReceived != null)
                    {
                        DataReceived(data);
                    }
                }
                catch
                {
                    break;
                }
            }

            Close();
        }
    }
}
