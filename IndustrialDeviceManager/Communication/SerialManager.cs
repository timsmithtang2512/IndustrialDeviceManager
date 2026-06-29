/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndustrialDeviceManager.Communication
{
    class SerialManager
    {
    }
}
 */
using System;
using System.IO.Ports;
using IndustrialDeviceManager.Common;

namespace IndustrialDeviceManager.Communication
{
    /// <summary>
    /// 串口通信管理类
    /// 适用于 VS2010
    /// </summary>
    public class SerialManager
    {
        private SerialPort serialPort;

        /// <summary>
        /// 接收到数据事件
        /// </summary>
        public event Action<byte[]> DataReceived;

        /// <summary>
        /// 是否打开
        /// </summary>
        public bool IsOpen
        {
            get
            {
                if (serialPort == null)
                    return false;

                return serialPort.IsOpen;
            }
        }

        public SerialManager()
        {
            serialPort = new SerialPort();

            serialPort.DataReceived +=
                serialPort_DataReceived;
        }

        /// <summary>
        /// 获取所有串口
        /// </summary>
        public static string[] GetPortNames()
        {
            return SerialPort.GetPortNames();
        }

        /// <summary>
        /// 打开串口
        /// </summary>
        public bool Open(
            string portName,
            int baudRate)
        {
            try
            {
                if (serialPort.IsOpen)
                    serialPort.Close();

                serialPort.PortName = portName;

                serialPort.BaudRate = baudRate;

                serialPort.DataBits = 8;

                serialPort.StopBits =
                    StopBits.One;

                serialPort.Parity =
                    Parity.None;

                serialPort.Open();

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 关闭串口
        /// </summary>
        public void Close()
        {
            if (serialPort == null)
                return;

            if (serialPort.IsOpen)
                serialPort.Close();
        }

        /// <summary>
        /// 发送HEX
        /// </summary>
        public void Send(byte[] data)
        {
            if (!serialPort.IsOpen)
                return;

            serialPort.Write(
                data,
                0,
                data.Length);
            Logger.Info(
            "发送：" +
            HexHelper.ByteToHex(data));

        }

        /// <summary>
        /// 发送字符串
        /// </summary>
        public void Send(string text)
        {
            if (!serialPort.IsOpen)
                return;

            serialPort.Write(text);
        }

        /// <summary>
        /// 接收事件
        /// </summary>
        void serialPort_DataReceived(
            object sender,
            SerialDataReceivedEventArgs e)
        {
            int len =
                serialPort.BytesToRead;

            byte[] buffer =
                new byte[len];

            serialPort.Read(
                buffer,
                0,
                len);

            if (DataReceived != null)
            {
                DataReceived(buffer);
            }

            Logger.Info(
            "接收：" +
            HexHelper.ByteToHex(buffer));

        }
    }
}
