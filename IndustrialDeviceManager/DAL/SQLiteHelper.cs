/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndustrialDeviceManager.DAL
{
    class SQLiteHelper
    {
    }
}
*/
using System;
using System.Data;
using System.Data.SQLite;
using System.Collections.Generic;

namespace IndustrialDeviceManager.DAL
{
    /// <summary>
    /// SQLite数据库帮助类
    /// 作者：ChatGPT
    /// 适用于 VS2010 + .NET Framework 4.0
    /// </summary>
    public class SQLiteHelper
    {
        /// <summary>
        /// 数据库文件
        /// </summary>
        public static readonly string DbPath =
        AppDomain.CurrentDomain.BaseDirectory +
        @"Database\Device.db";

        private static readonly string connStr =
            "Data Source=" + DbPath + ";Version=3;";

        /// <summary>
        /// 创建连接
        /// </summary>
        public static SQLiteConnection CreateConnection()
        {
            return new SQLiteConnection(connStr);
        }

        /// <summary>
        /// 执行 INSERT UPDATE DELETE
        /// </summary>
        public static int ExecuteNonQuery(string sql)
        {
            using (SQLiteConnection conn = CreateConnection())
            {
                conn.Open();

                using (SQLiteCommand cmd =
                    new SQLiteCommand(sql, conn))
                {
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 带参数执行
        /// </summary>
        public static int ExecuteNonQuery(
            string sql,
            params SQLiteParameter[] parameters)
        {
            using (SQLiteConnection conn = CreateConnection())
            {
                conn.Open();

                using (SQLiteCommand cmd =
                    new SQLiteCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 返回第一行第一列
        /// </summary>
        public static object ExecuteScalar(string sql)
        {
            using (SQLiteConnection conn = CreateConnection())
            {
                conn.Open();

                using (SQLiteCommand cmd =
                    new SQLiteCommand(sql, conn))
                {
                    return cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// 带参数返回第一行第一列
        /// </summary>
        public static object ExecuteScalar(
            string sql,
            params SQLiteParameter[] parameters)
        {
            using (SQLiteConnection conn = CreateConnection())
            {
                conn.Open();

                using (SQLiteCommand cmd =
                    new SQLiteCommand(sql, conn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    return cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// 查询DataTable
        /// </summary>
        public static DataTable ExecuteQuery(string sql)
        {
            using (SQLiteConnection conn = CreateConnection())
            {
                conn.Open();

                SQLiteDataAdapter adapter =
                    new SQLiteDataAdapter(sql, conn);

                DataTable table =
                    new DataTable();

                adapter.Fill(table);

                return table;
            }
        }

        /// <summary>
        /// 参数查询
        /// </summary>
        public static DataTable ExecuteQuery(
            string sql,
            params SQLiteParameter[] parameters)
        {
            using (SQLiteConnection conn = CreateConnection())
            {
                conn.Open();

                SQLiteCommand cmd =
                    new SQLiteCommand(sql, conn);

                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                SQLiteDataAdapter adapter =
                    new SQLiteDataAdapter(cmd);

                DataTable table =
                    new DataTable();

                adapter.Fill(table);

                return table;
            }
        }

        /// <summary>
        /// 执行事务
        /// </summary>
        public static bool ExecuteTransaction(
            List<string> sqlList)
        {
            using (SQLiteConnection conn =
                CreateConnection())
            {
                conn.Open();

                SQLiteTransaction tran =
                    conn.BeginTransaction();

                try
                {
                    foreach (string sql in sqlList)
                    {
                        SQLiteCommand cmd =
                            new SQLiteCommand(sql, conn);

                        cmd.Transaction = tran;

                        cmd.ExecuteNonQuery();
                    }

                    tran.Commit();

                    return true;
                }
                catch
                {
                    tran.Rollback();

                    return false;
                }
            }
        }

        /// <summary>
        /// 判断表是否存在
        /// </summary>
        public static bool TableExists(string tableName)
        {
            string sql =
                "SELECT COUNT(*) FROM sqlite_master " +
                "WHERE type='table' " +
                "AND name=@name";

            object obj =
                ExecuteScalar(
                sql,
                new SQLiteParameter("@name", tableName));

            return Convert.ToInt32(obj) > 0;
        }

        /// <summary>
        /// 判断数据库是否连接成功
        /// </summary>
        public static bool TestConnection()
        {
            try
            {
                using (SQLiteConnection conn =
                    CreateConnection())
                {
                    conn.Open();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}