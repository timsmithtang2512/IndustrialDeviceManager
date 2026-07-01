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
using System.Collections.Generic;
using System.Data;
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

        /// <summary>
        /// 查询全部日志
        /// </summary>
        public List<LogInfo> GetAll()
        {
            List<LogInfo> list =
                new List<LogInfo>();

            DataTable table =
                SQLiteHelper.ExecuteQuery(
                "SELECT * FROM Logs ORDER BY Id DESC");

            foreach (DataRow row in table.Rows)
            {
                LogInfo log =
                    new LogInfo();

                log.Id =
                    Convert.ToInt32(row["Id"]);

                log.LogLevel =
                    row["LogLevel"].ToString();

                log.Message =
                    row["Message"].ToString();

                log.CreateTime =
                    row["CreateTime"].ToString();

                list.Add(log);
            }

            return list;
        }
    }
}
