/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndustrialDeviceManager.DAL
{
    class LogRepository
    {
    }
}
*/
using System;
using System.Data.SQLite;
using IndustrialDeviceManager.Models;

namespace IndustrialDeviceManager.DAL
{
    /// <summary>
    /// 日志数据库
    /// </summary>
    public class LogRepository
    {
        /// <summary>
        /// 新增日志
        /// </summary>
        public bool Add(LogInfo log)
        {
            string sql =
            @"INSERT INTO Logs
            (
                LogLevel,
                Message,
                CreateTime
            )
            VALUES
            (
                @LogLevel,
                @Message,
                @CreateTime
            )";

            int rows =
                SQLiteHelper.ExecuteNonQuery(
                sql,

                new SQLiteParameter(
                    "@LogLevel",
                    log.LogLevel),

                new SQLiteParameter(
                    "@Message",
                    log.Message),

                new SQLiteParameter(
                    "@CreateTime",
                    log.CreateTime));

            return rows > 0;
        }
    }
}