using RacingMachinez.TrayApplication.Configuration;
using RacingMachinez.TrayApplication.Configuration.Interfaces;
using RacingMachinez.TrayApplication.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace RacingMachinez.TrayApplication
{
    static class Program
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [STAThread]
        static void Main()
        {
            bool createdNew = true;
            using (var mutex = new Mutex(true, Resources.Strings.ApplicationName, out createdNew))
            {
                if (createdNew)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(CompositionRoot.Create());
                }
                else
                {
                    var currentProcess = Process.GetCurrentProcess();
                    var otherProcess = Process.GetProcessesByName(currentProcess.ProcessName).FirstOrDefault(p => p.Id != currentProcess.Id);
                    if (otherProcess != null)
                    {
                        SetForegroundWindow(otherProcess.MainWindowHandle);
                    }
                }
            }
        }
    }
}
