/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndustrialDeviceManager.Communication
{
    class TcpServerManager
    {
    }
}
 */
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace IndustrialDeviceManager.Communication
{
    /// <summary>
    /// TCP服务器
    /// </summary>
    public class TcpServerManager
    {
        private TcpListener listener;

        private Thread listenThread;

        private List<TcpClient> clients =
            new List<TcpClient>();

        public event Action<TcpClient> ClientConnected;

        public event Action<TcpClient> ClientDisconnected;

        public event Action<TcpClient, byte[]> DataReceived;

        public bool IsRunning
        {
            get
            {
                return listener != null;
            }
        }

        /// <summary>
        /// 启动服务器
        /// </summary>
        public bool Start(int port)
        {
            try
            {
                listener =
                    new TcpListener(
                        IPAddress.Any,
                        port);

                listener.Start();

                listenThread =
                    new Thread(ListenThread);

                listenThread.IsBackground = true;

                listenThread.Start();

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 停止服务器
        /// </summary>
        public void Stop()
        {
            try
            {
                if (listener != null)
                {
                    listener.Stop();
                }

                lock (clients)
                {
                    foreach (TcpClient c in clients)
                    {
                        c.Close();
                    }

                    clients.Clear();
                }

                listener = null;
            }
            catch
            {
            }
        }

        /// <summary>
        /// 监听线程
        /// </summary>
        private void ListenThread()
        {
            while (listener != null)
            {
                try
                {
                    TcpClient client =
                        listener.AcceptTcpClient();

                    lock (clients)
                    {
                        clients.Add(client);
                    }

                    if (ClientConnected != null)
                    {
                        ClientConnected(client);
                    }

                    Thread t =
                        new Thread(ClientThread);

                    t.IsBackground = true;

                    t.Start(client);
                }
                catch
                {
                    break;
                }
            }
        }

        /// <summary>
        /// 每个客户端线程
        /// </summary>
        private void ClientThread(object obj)
        {
            TcpClient client =
                (TcpClient)obj;

            NetworkStream stream =
                client.GetStream();

            byte[] buffer =
                new byte[4096];

            try
            {
                while (client.Connected)
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
                        DataReceived(
                            client,
                            data);
                    }
                }
            }
            catch
            {
            }

            lock (clients)
            {
                clients.Remove(client);
            }

            if (ClientDisconnected != null)
            {
                ClientDisconnected(client);
            }

            client.Close();
        }

        /// <summary>
        /// 发送给一个客户端
        /// </summary>
        public void Send(
            TcpClient client,
            byte[] data)
        {
            if (client == null)
                return;

            if (!client.Connected)
                return;

            NetworkStream stream =
                client.GetStream();

            stream.Write(
                data,
                0,
                data.Length);
        }

        /// <summary>
        /// 广播发送
        /// </summary>
        public void Broadcast(byte[] data)
        {
            lock (clients)
            {
                foreach (TcpClient c in clients)
                {
                    if (c.Connected)
                    {
                        Send(c, data);
                    }
                }
            }
        }

        /// <summary>
        /// 当前连接数量
        /// </summary>
        public int ClientCount
        {
            get
            {
                lock (clients)
                {
                    return clients.Count;
                }
            }
        }
    }
}
