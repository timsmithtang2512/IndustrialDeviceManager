/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndustrialDeviceManager.Models
{
    class LogInfo
    {
    }
}
 */
using System;

namespace IndustrialDeviceManager.Models
{
    /// <summary>
    /// 日志对象
    /// </summary>
    public class LogInfo
    {
        public int Id { get; set; }

        public string LogLevel { get; set; }

        public string Message { get; set; }

        public string CreateTime { get; set; }

        public override string ToString()
        {
            return
                CreateTime
                + " "
                + LogLevel
                + " "
                + Message;
        }
    }
} 
