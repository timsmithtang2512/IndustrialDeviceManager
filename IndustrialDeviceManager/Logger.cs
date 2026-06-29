/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndustrialDeviceManager
{
    class Logger
    {
    }
}
 */
using System;
using System.IO;
using IndustrialDeviceManager.DAL;
using IndustrialDeviceManager.Models;

namespace IndustrialDeviceManager.Common
{
    /// <summary>
    /// 日志类
    /// </summary>
    public static class Logger
    {
        private static readonly object locker = new object();

        private static string LogFolder
        {
            get
            {
                string folder =
                    AppDomain.CurrentDomain.BaseDirectory + "Logs";

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                return folder;
            }
        }

        private static string LogFile
        {
            get
            {
                return Path.Combine(
                    LogFolder,
                    DateTime.Now.ToString("yyyyMMdd") + ".log");
            }
        }

        public static void Info(string message)
        {
            Write("INFO", message);
        }

        public static void Error(string message)
        {
            Write("ERROR", message);
        }

        public static void Debug(string message)
        {
            Write("DEBUG", message);
        }

        private static void Write(string level, string message)
        {
            lock (locker)
            {
                string line =
                    string.Format(
                        "{0} [{1}] {2}",
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        level,
                        message);

                File.AppendAllText(
                    LogFile,
                    line + Environment.NewLine);
            }


            try
            {
                LogRepository repo =
                    new LogRepository();

                LogInfo log =
                    new LogInfo();

                log.LogLevel = level;

                log.Message = message;

                log.CreateTime =
                    DateTime.Now.ToString(
                    "yyyy-MM-dd HH:mm:ss");

                repo.Add(log);
            }
            catch
            {
            }

        }
    }
}
 
