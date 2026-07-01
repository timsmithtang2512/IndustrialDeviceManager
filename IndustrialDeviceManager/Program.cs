/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace IndustrialDeviceManager
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
*/
using System;
using System.Windows.Forms;
using IndustrialDeviceManager.DAL;

namespace IndustrialDeviceManager
{
    static class Program
    {
        /// <summary>
        /// 程序入口
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();

            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                DatabaseInitializer.Initialize();
            }
            catch (BadImageFormatException ex)
            {
                MessageBox.Show(
                    "SQLite组件位数与程序平台不一致，请确认程序和System.Data.SQLite/SQLite.Interop.dll均为x64或均为x86。\r\n\r\n" +
                    ex.Message,
                    "SQLite加载失败",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "数据库初始化失败：\r\n" + ex.Message,
                    "启动失败",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            Application.Run(new MainForm());
        }
    }
}
