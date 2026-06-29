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

            DatabaseInitializer.Initialize();

            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new MainForm());
        }
    }
}