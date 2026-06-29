/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndustrialDeviceManager.Common
{
    class HexHelper
    {
    }
}
 */
using System;
using System.Text;

namespace IndustrialDeviceManager.Common
{
    /// <summary>
    /// 十六进制转换
    /// </summary>
    public class HexHelper
    {
        /// <summary>
        /// Byte转HEX
        /// </summary>
        public static string ByteToHex(byte[] data)
        {
            if (data == null)
                return "";

            StringBuilder sb =
                new StringBuilder();

            foreach (byte b in data)
            {
                sb.Append(
                    b.ToString("X2"));

                sb.Append(" ");
            }

            return sb.ToString();
        }

        /// <summary>
        /// HEX转Byte
        /// </summary>
        public static byte[] HexToByte(
            string hex)
        {
            hex =
                hex.Replace(" ", "");

            int len =
                hex.Length / 2;

            byte[] buffer =
                new byte[len];

            for (int i = 0; i < len; i++)
            {
                buffer[i] =
                    Convert.ToByte(
                    hex.Substring(
                        i * 2,
                        2),
                    16);
            }

            return buffer;
        }
    }
}
