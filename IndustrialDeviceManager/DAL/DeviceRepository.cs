/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndustrialDeviceManager.DAL
{
    class DeviceRepository
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
    /// Device数据访问
    /// </summary>
    public class DeviceRepository
    {

        /// <summary>
        /// 新增设备
        /// </summary>
        public bool Add(DeviceInfo device)
        {
            string sql =
            @"INSERT INTO Devices
            (
                DeviceName,
                DeviceType,
                SerialNumber,
                Status,
                CreateTime
            )
            VALUES
            (
                @DeviceName,
                @DeviceType,
                @SerialNumber,
                @Status,
                @CreateTime
            )";

            int rows =
                SQLiteHelper.ExecuteNonQuery(
                sql,

                new SQLiteParameter(
                    "@DeviceName",
                    device.DeviceName),

                new SQLiteParameter(
                    "@DeviceType",
                    device.DeviceType),

                new SQLiteParameter(
                    "@SerialNumber",
                    device.SerialNumber),

                new SQLiteParameter(
                    "@Status",
                    device.Status),

                new SQLiteParameter(
                    "@CreateTime",
                    device.CreateTime));

            return rows > 0;
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        public List<DeviceInfo> GetAll()
        {
            List<DeviceInfo> list =
                new List<DeviceInfo>();

            DataTable table =
                SQLiteHelper.ExecuteQuery(
                "SELECT * FROM Devices");

            foreach (DataRow row in table.Rows)
            {
                DeviceInfo d =
                    new DeviceInfo();

                d.Id =
                    Convert.ToInt32(row["Id"]);

                d.DeviceName =
                    row["DeviceName"].ToString();

                d.DeviceType =
                    row["DeviceType"].ToString();

                d.SerialNumber =
                    row["SerialNumber"].ToString();

                d.Status =
                    row["Status"].ToString();

                d.CreateTime =
                    row["CreateTime"].ToString();

                list.Add(d);
            }

            return list;
        }

        /// <summary>
        /// 删除
        /// </summary>
        public bool Delete(int id)
        {
            string sql =
                "DELETE FROM Devices WHERE Id=@Id";

            int rows =
                SQLiteHelper.ExecuteNonQuery(
                sql,
                new SQLiteParameter("@Id", id));

            return rows > 0;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public bool Update(DeviceInfo device)
        {
            string sql =
            @"UPDATE Devices SET

            DeviceName=@DeviceName,

            DeviceType=@DeviceType,

            SerialNumber=@SerialNumber,

            Status=@Status

            WHERE Id=@Id";

            int rows =
                SQLiteHelper.ExecuteNonQuery(
                sql,

                new SQLiteParameter(
                    "@DeviceName",
                    device.DeviceName),

                new SQLiteParameter(
                    "@DeviceType",
                    device.DeviceType),

                new SQLiteParameter(
                    "@SerialNumber",
                    device.SerialNumber),

                new SQLiteParameter(
                    "@Status",
                    device.Status),

                new SQLiteParameter(
                    "@Id",
                    device.Id));

            return rows > 0;
        }
    }
}
