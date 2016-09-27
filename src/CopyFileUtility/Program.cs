using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CopyFileUtility
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args != null && args.Length == 1)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMain(new FileInfo(args[0])));
            }
        }
    }
}
