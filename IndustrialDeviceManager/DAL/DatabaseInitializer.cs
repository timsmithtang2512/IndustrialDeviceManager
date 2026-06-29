/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndustrialDeviceManager.DAL
{
    class DatabaseInitializer
    {
    }
}
 */
using System;
using System.IO;
using System.Data.SQLite;
using IndustrialDeviceManager.Common;

namespace IndustrialDeviceManager.DAL
{
    /// <summary>
    /// 数据库初始化
    /// </summary>
    public class DatabaseInitializer
    {
        /// <summary>
        /// 初始化数据库
        /// </summary>
        public static void Initialize()
        {
            try
            {
                CreateFolder();

                CreateDatabase();

                CreateTables();

                Logger.Info("数据库初始化成功");
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString());

                throw;
            }
        }

        /// <summary>
        /// 创建Database目录
        /// </summary>
        private static void CreateFolder()
        {
            string folder =
                AppDomain.CurrentDomain.BaseDirectory +
                "Database";

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
        }

        /// <summary>
        /// 创建数据库
        /// </summary>
        private static void CreateDatabase()
        {
            if (!File.Exists(SQLiteHelper.DbPath))
            {
                SQLiteConnection.CreateFile(
                    SQLiteHelper.DbPath);
            }
        }

        /// <summary>
        /// 创建所有数据表
        /// </summary>
        private static void CreateTables()
        {
            CreateUsersTable();

            CreateDevicesTable();

            CreateLogsTable();

            CreateConfigTable();
        }

        /// <summary>
        /// Users
        /// </summary>
        private static void CreateUsersTable()
        {
            string sql =
            @"CREATE TABLE IF NOT EXISTS Users
            (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,

                UserName TEXT NOT NULL,

                Password TEXT NOT NULL,

                CreateTime TEXT
            );";

            SQLiteHelper.ExecuteNonQuery(sql);

            object obj =
                SQLiteHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM Users");

            if (Convert.ToInt32(obj) == 0)
            {
                SQLiteHelper.ExecuteNonQuery(
                @"INSERT INTO Users
                (UserName,Password,CreateTime)
                VALUES
                ('admin','123456',datetime('now'))");
            }
        }

        /// <summary>
        /// Devices
        /// </summary>
        private static void CreateDevicesTable()
        {
            string sql =
            @"CREATE TABLE IF NOT EXISTS Devices
            (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,

                DeviceName TEXT,

                DeviceType TEXT,

                SerialNumber TEXT,

                Status TEXT,

                CreateTime TEXT
            );";

            SQLiteHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// Logs
        /// </summary>
        private static void CreateLogsTable()
        {
            string sql =
            @"CREATE TABLE IF NOT EXISTS Logs
            (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,

                LogLevel TEXT,

                Message TEXT,

                CreateTime TEXT
            );";

            SQLiteHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// Config
        /// </summary>
        private static void CreateConfigTable()
        {
            string sql =
            @"CREATE TABLE IF NOT EXISTS Config
            (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,

                ConfigKey TEXT,

                ConfigValue TEXT
            );";

            SQLiteHelper.ExecuteNonQuery(sql);
        }
    }
}
