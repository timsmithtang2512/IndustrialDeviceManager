/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndustrialDeviceManager.Models
{
    class DeviceInfo
    {
    }
}
 */
using System;

namespace IndustrialDeviceManager.Models
{
    /// <summary>
    /// 设备信息
    /// </summary>
    public class DeviceInfo
    {
        public int Id { get; set; }

        public string DeviceName { get; set; }

        public string DeviceType { get; set; }

        public string SerialNumber { get; set; }

        public string Status { get; set; }

        public string CreateTime { get; set; }
    }
}
